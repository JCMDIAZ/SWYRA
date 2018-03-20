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
        private CodigosBarra cod = new CodigosBarra();
        private DetallePedidoMerc art;
        private string lastCB;
        private string Lote;

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
                var query = "SELECT CVE_ART, CANT_PIEZAS, CODIGO_BARRA FROM vw_codigosBarras " +
                             "WHERE CODIGO_BARRA = '" + txtCodigo.Text + "'";
                cod = Program.GetDataTable(query, 2).ToData<CodigosBarra>();
                if (cod != null)
                {
                    var tot = det.Count(o => o.codigo_barra == cod.codigo_barra);
                    if(tot == 0)
                    {
                        MessageBox.Show(@"Artículo no registrado en la lista del surtido", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        txtCodigo.Focus();
                    }
                    else if(tot == 1)
                    {
                        art = det.First(o => o.codigo_barra == cod.codigo_barra);
                        query = "DELETE DETALLEPEDIDOMERC WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "' AND " +
                                "CONSEC = " + art.consec;

                    }
                    else if (tot > 1)
                    {
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
        }

        private void dgDetallePed_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void FrmDevolucion_Load(object sender, EventArgs e)
        {
            det = CargaDetalleMerc();
        }

        private List<DetallePedidoMerc> CargaDetalleMerc()
        {
            List<DetallePedidoMerc> tmp = new List<DetallePedidoMerc>();
            try
            {
                var query = "SELECT CVE_DOC, CONSEC, NUM_PAR, dt.CVE_ART, CODIGO_BARRA, CANT, TIPOPAQUETE, CONSEC_PADRE, ULTIMO, i.DESCR " +
                            "FROM DETALLEPEDIDOMERC dt JOIN INVENTARIO i ON dt.CVE_ART = i.CVE_ART WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "'";
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

        }

        private void txtCant_LostFocus(object sender, EventArgs e)
        {

        }
    }
}