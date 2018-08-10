using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SWYRA_Movil
{
    public partial class FrmDevolucion : Form
    {
        public Pedidos ped = new Pedidos();
        public List<DetallePedidoMerc> det = new List<DetallePedidoMerc>();
        public bool Area = false;
        private CodigosBarra cod = new CodigosBarra();
        private DetallePedidoMerc art;
        private string lastCB;

        public FrmDevolucion()
        {
            InitializeComponent();
        }

        private void pbSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Return))
            {
                txtDescr.Focus();
                e.Handled = true;
            }
        }

        private void txtCodigo_LostFocus(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                return;
            }
            lastCB = txtCodigo.Text;
            txtCant.Value = 1;
            txtDescr.Text = "";
            try
            {
                var str = txtCodigo.Text.Split('-');
                var query = "SELECT CVE_ART, CANT_PIEZAS, CODIGO_BARRA FROM vw_codigosBarras " +
                             "WHERE CODIGO_BARRA = '" + str[0] + "'";
                cod = Program.GetDataTable(query, 2).ToData<CodigosBarra>();
                if (str.Length == 2)
                {
                    //txtCodigo.Text = str[0];
                    cod.cant_piezas = Convert.ToInt32(str[1]);
                }
                if (cod != null && str.Length <= 2)
                {
                    var tot = det.Count(o => o.codigo_barra == txtCodigo.Text);
                    if(tot == 0)
                    {
                        MessageBox.Show(@"Artículo no registrado en la lista del surtido", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        txtCodigo.Focus();
                    }
                    else if(tot == 1)
                    {
                        txtCant.ReadOnly = true; // !(cod.cant_piezas == 1);
                        txtCant.Value = cod.cant_piezas;
                        art = det.Find(o => o.codigo_barra == txtCodigo.Text && (o.cancelado == null || o.cancelado == false));
                        art.cancelado = (cod.cant_piezas != 1);
                        actualizaDet();
                        if (cod.cant_piezas == 1) { txtCant.Focus(); }
                    }
                }
                else
                {
                    MessageBox.Show(@"Código de Barra INEXISTENTE, favor de validar.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            if (txtCant.ReadOnly)
            {
                txtCodigo.Text = "";
                txtCodigo.Focus();
            }
        }

        private void actualizaDet()
        {
            if (txtCant.ReadOnly)
            {
                var query = "UPDATE DETALLEPEDIDOMERC SET Cancelado = " + (art.cancelado ? "1" : "0") + ", " +
                            "CANT = " + art.cant + " WHERE CVE_DOC  = '" + art.cve_doc + "' AND CONSEC = " + art.consec.ToString() +
                            " UPDATE DETALLEPEDIDO SET CANTSURTIDO = CANTSURTIDO - " + txtCant.Value.ToString() +
                            ", SURTIDO = 0 WHERE CVE_DOC = '" + art.cve_doc + "' AND NUM_PAR = " + art.num_par.ToString() +
                            " UPDATE INVENTARIO SET EXIST = EXIST + " + txtCant.Value.ToString() + " WHERE CVE_ART = '" + art.cve_art + "' " +
                            "update PEDIDO set PORC_SURTIDO = r.porc from PEDIDO p join ( " +
                            "select CVE_DOC, (sum(CAST(ISNULL(SURTIDO,0) AS float)) / CAST(count(SURTIDO) as float)) * 100.0 porc from DETALLEPEDIDO " +
                            "where CVE_DOC = '" + art.cve_doc + "' group by CVE_DOC) as r ON p.CVE_DOC = r.CVE_DOC ";
                Program.GetExecute(query, 3);
                det = CargaDetalleMerc();
                dgDetallePed.DataSource = Program.ToDataTable<DetallePedidoMerc>(det, "detallePedidoMerc");
            }
        }

        private void dgDetallePed_CurrentCellChanged(object sender, EventArgs e)
        {
            dgDetallePed.Select(dgDetallePed.CurrentRowIndex);
        }

        private void FrmDevolucion_Load(object sender, EventArgs e)
        {
            det = CargaDetalleMerc();
            dgDetallePed.DataSource = Program.ToDataTable<DetallePedidoMerc>(det, "detallePedidoMerc");
        }

        private List<DetallePedidoMerc> CargaDetalleMerc()
        {
            List<DetallePedidoMerc> tmp = new List<DetallePedidoMerc>();
            try
            {
                var query = "SELECT CVE_DOC, CONSEC, NUM_PAR, dt.CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, CONSEC_PADRE, ULTIMO, i.DESCR, CTRL_ALM " +
                            "FROM DETALLEPEDIDOMERC dt JOIN INVENTARIO i ON dt.CVE_ART = i.CVE_ART " +
                            "LEFT JOIN ORDEN_RUTA o ON RTRIM(LTRIM(CTRL_ALM)) = o.CVE_UBI " +
                            "JOIN AREAS r ON ISNULL(o.AREA,'') " + (Area ? "" : "NOT") + " like '%' + r.NOMBRE + '%' " +
                            "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "' AND ISNULL(CANCELADO,0) = 0 " +
                            "ORDER BY CONSEC";
                tmp = Program.GetDataTable(query, 1).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Artículo NO ASIGNADO al pedido.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return tmp;
        }

        private void txtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Return))
            {
                if ((double)txtCant.Value > art.cant)
                {
                    txtCant.Value = (decimal)art.cant;
                    MessageBox.Show(@"Artículo excede a la cantidad solicitada.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    art.cant -= (int)txtCant.Value;
                    art.cancelado = (art.cant == 0);
                    txtCant.ReadOnly = true;
                    txtCodigo.Text = "";
                    txtCodigo.Focus();
                    e.Handled = true;
                }
            }
        }

        private void txtCant_LostFocus(object sender, EventArgs e)
        {
            actualizaDet();
        }
    }
}