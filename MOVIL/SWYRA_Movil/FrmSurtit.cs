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
    public partial class FrmSurtit : Form
    {
        public Pedidos ped = new Pedidos();
        public List<DetallePedidos> det = new List<DetallePedidos>();
        private CodigosBarra cod = new CodigosBarra();
        private DetallePedidos art = new DetallePedidos();
        private string lastCB;
        private string Lote;

        public FrmSurtit()
        {
            InitializeComponent();
        }

        private void pbSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSurtit_Load(object sender, EventArgs e)
        {
            var mostrardet = det.Where(o => o.surtido == false).ToList();
            dgDetallePed.DataSource = Program.ToDataTable<DetallePedidos>(mostrardet, "detallePedidos");
            lblPedido.Text = ped.cve_doc.Trim();
            lblComentario.Text = "";
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Return))
            {
                txtLinea.Focus();
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
            txtLinea.Text = "";
            txtDescr.Text = "";
            lblComentario.Text = "";
            try
            {
                var query = "SELECT CVE_ART, CANT_PIEZAS, CODIGO_BARRA FROM vw_codigosBarras " +
                             "WHERE CODIGO_BARRA = '" + txtCodigo.Text + "'";
                cod = Program.GetDataTable(query, 1).ToData<CodigosBarra>();
                if (cod != null)
                {
                    try
                    {
                        art = det.First(o => o.cve_art == cod.cve_art);
                        if (art.surtido)
                        {
                            MessageBox.Show(@"Artículo ya se encuentra surtido", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            if (cod.cant_piezas > art.cantdiferencia)
                            {
                                MessageBox.Show(@"Presentación del artículo excede a la cantidad solicitada.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                            }
                            else
                            {
                                if (cod.cant_piezas > art.exist)
                                {
                                    MessageBox.Show(@"Artículo NO HAY EN EXISTENCIA.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                }
                                else
                                {
                                    DialogResult dr = DialogResult.OK;
                                    if (art.lin_prod.Contains("EXHIB"))
                                    {
                                        FrmSurtir2 frmConf1 = new FrmSurtir2();
                                        dr = frmConf1.ShowDialog();
                                        frmConf1.Close();
                                    }
                                    if (art.aplicalote)
                                    {
                                        FrmSurtir3 frmConf2 = new FrmSurtir3();
                                        frmConf2.ShowDialog();
                                        Lote = frmConf2.txtLote.Text;
                                        frmConf2.Close();
                                    }
                                    txtCant.ReadOnly = !(cod.cant_piezas == 1 || dr == DialogResult.Cancel);
                                    txtCant.Value = cod.cant_piezas;
                                    txtLinea.Text = art.lin_prod;
                                    txtDescr.Text = art.descr;
                                    lblComentario.Text = art.comentario;
                                    actualizaDet();
                                    if (cod.cant_piezas == 1) { txtCant.Focus(); }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(@"Artículo NO ASIGNADO al pedido.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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

        private void txtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Return))
            {
                if ((double)txtCant.Value > art.cantdiferencia)
                {
                    txtCant.Value = (decimal)art.cantdiferencia;
                    MessageBox.Show(@"Artículo excede a la cantidad solicitada.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if ((double)txtCant.Value > art.exist)
                    {
                        txtCant.Value = (decimal)art.exist;
                        MessageBox.Show(@"Artículo EXCEDE EN EXISTENCIA.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
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
        }

        private void actualizaDet()
        {
            if (txtCant.ReadOnly)
            {
                art.cantsurtido += (double)txtCant.Value;
                art.cantdiferencia = art.cant - art.cantsurtido;
                art.surtido = (art.cant == art.cantsurtido);
                art.exist = (art.exist - art.cantsurtido);
                var query = "DECLARE @consec INT " +
                            "SELECT @consec = (ISNULL(MAX(CONSEC),-1) + 1) FROM DETALLEPEDIDOMERC " +
                            "WHERE CVE_DOC = '" + art.cve_doc + "' " +
                            "INSERT DETALLEPEDIDOMERC (CVE_DOC, CONSEC, NUM_PAR, CVE_ART, CODIGO_BARRA, CANT) " +
                            "VALUES ('" + art.cve_doc + "', @consec, " + art.num_par.ToString() + ", '" + art.cve_art +
                            "', '" + lastCB + "', " + txtCant.Value.ToString() + ") " +
                            "UPDATE DETALLEPEDIDO SET CANTSURTIDO = " + art.cantsurtido +
                            ", SURTIDO = " + ((art.surtido) ? "1" : "0") +
                            " WHERE CVE_DOC = '" + art.cve_doc + "' AND NUM_PAR = " + art.num_par.ToString() +
                            " UPDATE INVENTARIO SET EXIST = EXIST - " + txtCant.Value.ToString() + " WHERE CVE_ART = '" + art.cve_art + "' " +
                            "update PEDIDO set PORC_SURTIDO = r.porc from PEDIDO p join ( " +
                            "select CVE_DOC, (sum(CAST(ISNULL(SURTIDO,0) AS float)) / CAST(count(SURTIDO) as float)) * 100.0 porc from DETALLEPEDIDO " +
                            "where CVE_DOC = '" + art.cve_doc + "' group by CVE_DOC) as r ON p.CVE_DOC = r.CVE_DOC ";
                Program.GetExecute(query, 2);

                var mostrardet = det.Where(o => o.surtido == false).ToList();
                dgDetallePed.DataSource = Program.ToDataTable<DetallePedidos>(mostrardet, "detallePedidos");
            }
        }

        private void txtCant_LostFocus(object sender, EventArgs e)
        {
            actualizaDet();
        }

        private void dgDetallePed_CurrentCellChanged(object sender, EventArgs e)
        {
            dgDetallePed.Select(dgDetallePed.CurrentRowIndex);
        }

        private void pbIncompleto_Click(object sender, EventArgs e)
        {
            var index = dgDetallePed.CurrentRowIndex;
            if (index >= 0)
            {
                art = det.First(o => o.num_par == int.Parse(dgDetallePed[index, 6].ToString()));
                art.surtido = true;
                var query = "UPDATE DETALLEPEDIDO SET SURTIDO = " + ((art.surtido) ? "1" : "0") +
                            " WHERE CVE_DOC = '" + art.cve_doc + "' AND NUM_PAR = " + art.num_par.ToString() + " " +
                            "update PEDIDO set PORC_SURTIDO = r.porc from PEDIDO p join ( " +
                            "select CVE_DOC, (sum(CAST(ISNULL(SURTIDO,0) AS float)) / CAST(count(SURTIDO) as float)) * 100.0 porc from DETALLEPEDIDO " +
                            "where CVE_DOC = '" + art.cve_doc + "' group by CVE_DOC) as r ON p.CVE_DOC = r.CVE_DOC ";
                Program.GetExecute(query, 3);
                var mostrardet = det.Where(o => o.surtido == false).ToList();
                dgDetallePed.DataSource = Program.ToDataTable<DetallePedidos>(mostrardet, "detallePedidos");
            }
        }
    }
}