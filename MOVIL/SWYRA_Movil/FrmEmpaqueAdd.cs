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
    public partial class FrmEmpaqueAdd : Form
    {
        public DetallePedidoMerc ped;
        private List<DetallePedidoMerc> det = new List<DetallePedidoMerc>();
        private CodigosBarra cod = new CodigosBarra();
        private DetallePedidoMerc art;
        public string proceso = "EMP";

        public FrmEmpaqueAdd()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Return))
            {
                if ((double)txtCant.Value > art.cant)
                {
                    txtCant.Value = (decimal)art.cant;
                    MessageBox.Show(@"Artículo excede con la cantidad solicitada.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    txtCant.ReadOnly = true;
                    txtCodigo.Text = "";
                    txtCodigo.Focus();
                    e.Handled = true;
                }
            }
        }

        private void txtCant_LostFocus(object sender, EventArgs e)
        {
            art.consec_padre = (proceso == "EMP") ? ped.consec : 0;
            //actualizaDet();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Return))
            {
                pbSalir.Focus();
                e.Handled = true;
            }
        }

        private void txtCodigo_LostFocus(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                return;
            }
            txtCant.Value = 1;
            try
            {
                var str = txtCodigo.Text.Split('-');
                var query = "SELECT CVE_ART, CANT_PIEZAS, CODIGO_BARRA FROM vw_codigosBarras " +
                             "WHERE CODIGO_BARRA = '" + str[0] + "'";
                cod = Program.GetDataTable(query, 2).ToData<CodigosBarra>();
                if (cod != null)
                {
                    if (str.Length == 2)
                    {
                        //txtCodigo.Text = str[0];
                        cod.cant_piezas = Convert.ToInt32(str[1]);
                    }
                    if (str.Length <= 2)
                    {
                        var tot = det.Count(o => o.codigo_barra == txtCodigo.Text);
                        if (tot == 0)
                        {
                            MessageBox.Show(@"Artículo no registrado en la lista del surtido", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            txtCodigo.Focus();
                        }
                        else
                        {
                            //txtCant.ReadOnly = !(cod.cant_piezas == 1);
                            txtCant.Value = cod.cant_piezas;
                            if (proceso == "EMP")
                            {
                                art = det.Find(o => o.codigo_barra == txtCodigo.Text && (o.cancelado == null || o.cancelado == false) && (o.consec_padre == null || o.consec_padre == 0));
                            }
                            else
                            {
                                art = det.Find(o => o.codigo_barra == txtCodigo.Text && (o.cancelado == null || o.cancelado == false) && o.consec_padre == ped.consec);
                            }
                            if (art == null)
                            {
                                if (proceso == "EMP")
                                {
                                    MessageBox.Show(@"Artículo ya empaquetado favor de validar", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                }
                                else
                                {
                                    MessageBox.Show(@"Artículo no empaquetado en esta " + ped.tipopaquete + " favor de validar", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                }
                                txtCodigo.Focus();
                            }
                            else
                            {
                                art.consec_padre = (proceso == "EMP") ? ped.consec : 0;
                                actualizaDet();
                                //if (cod.cant_piezas == 1) { txtCant.Focus(); }
                            }
                        }
                    }
                }
                else
                {
                    var msj = @"Código de Barra INEXISTENTE, favor de validar.";
                    MessageBox.Show(msj, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            if (txtCant.ReadOnly)
            {
                txtCant.Value = 1;
                txtCodigo.Text = "";
                txtCodigo.Focus();
            }
        }

        private void actualizaDet()
        {
            if (txtCant.ReadOnly)
            {
                if ((double)txtCant.Value < art.cant)
                {
                    var query2 = "UPDATE DETALLEPEDIDOMERC SET CANT = " + txtCant.Value.ToString() + " " +
                                 "WHERE CVE_DOC  = '" + art.cve_doc + "' AND CONSEC = " + art.consec.ToString();
                    Program.GetExecute(query2, 7);
                    var dif = art.cant - (double)txtCant.Value;
                    query2 = "DECLARE @consec INT " +
                            "SELECT @consec = (ISNULL(MAX(CONSEC),-1) + 1) FROM DETALLEPEDIDOMERC " +
                            "WHERE CVE_DOC = '" + art.cve_doc + "' " +
                            "INSERT DETALLEPEDIDOMERC (CVE_DOC, CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, CANT) " +
                            "VALUES ('" + art.cve_doc + "', @consec, " + art.num_par.ToString() + ", '" + art.cve_art +
                            "', '" + art.codigo_barra + "', " + dif.ToString() + ") ";
                    Program.GetExecute(query2, 8);
                }
                var query = "UPDATE DETALLEPEDIDOMERC SET CONSEC_PADRE = " + ((proceso == "EMP") ? art.consec_padre.ToString() : "NULL")  + " " +
                            "WHERE CVE_DOC  = '" + art.cve_doc + "' AND CONSEC = " + art.consec.ToString() +
                            " UPDATE DETALLEPEDIDOMERC SET TotArt = isnull(TotArt,0) " + ((proceso == "EMP") ? "+" : "-") + " 1 " +
                            "WHERE CVE_DOC  = '" + ped.cve_doc + "' AND CONSEC = " + ped.consec.ToString() +
                            " UPDATE PEDIDO set PORC_EMPAQUE = (cast(r.ent as float) / cast(r.sal as float)) * 100.0 from PEDIDO p join ( " +
                            "SELECT CVE_DOC, sum(case when isnull(TIPOPAQUETE, '') = '' and isnull(CONSEC_PADRE,'') <> '' then 1 else 0 end) ent, " +
                            "sum(case when isnull(TIPOPAQUETE, '') = '' then 1 else 0 end) sal " +
                            "FROM DETALLEPEDIDOMERC WHERE CVE_DOC = '" + art.cve_doc + "' AND (ISNULL(CANCELADO, 0) = 0) group by CVE_DOC) " +
                            "as r ON p.CVE_DOC = r.CVE_DOC ";
                Program.GetExecute(query, 3);
                det = CargaDetalleMerc();
                var mostrardet = det.Where(o => o.consec_padre == ped.consec).ToList();
                dgDetallePed.DataSource = Program.ToDataTable<DetallePedidoMerc>(mostrardet, "detallePedidoMerc");
            }
        }

        private void dgDetallePed_CurrentCellChanged(object sender, EventArgs e)
        {
            dgDetallePed.Select(dgDetallePed.CurrentRowIndex);
        }

        private void FrmEmpaqueAdd_Load(object sender, EventArgs e)
        {
            lblEstatusB.Visible = (proceso != "EMP");
            lblEstatusA.Visible = (proceso == "EMP");
            lblPedido.Text = ped.cve_doc.Trim();
            lblPaquete.Text = "(" + ped.consec_empaque.ToString() + ") - " + ped.tipopaquete;
            det = CargaDetalleMerc();
            var mostrardet = det.Where(o => o.consec_padre == ped.consec).ToList();
            dgDetallePed.DataSource = Program.ToDataTable<DetallePedidoMerc>(mostrardet, "detallePedidoMerc");
        }

        private List<DetallePedidoMerc> CargaDetalleMerc()
        {
            List<DetallePedidoMerc> tmp = new List<DetallePedidoMerc>();
            try
            {
                var query = "SELECT CVE_DOC, CONSEC, NUM_PAR, dt.CVE_ART, CODIGO_BARRA, CASE WHEN CANT = 0 THEN TOTART ELSE CANT END CANT, " +
                            "TIPOPAQUETE, CONSEC_PADRE, ULTIMO, isnull(i.DESCR, TIPOPAQUETE) DESCR " +
                            "FROM DETALLEPEDIDOMERC dt LEFT JOIN INVENTARIO i ON dt.CVE_ART = i.CVE_ART " +
                            "WHERE CVE_DOC = '" + ped.cve_doc + "' AND ISNULL(CANCELADO,0) = 0 " +
                            "AND ISNULL(TIPOPAQUETE,'') = '' ORDER BY CONSEC DESC";
                tmp = Program.GetDataTable(query, 1).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return tmp;
        }

        private void pbCambia_Click(object sender, EventArgs e)
        {
            proceso = (proceso == "EMP") ? "DES" : "EMP";
            lblEstatusB.Visible = (proceso != "EMP");
            lblEstatusA.Visible = (proceso == "EMP");
        }
    }
}