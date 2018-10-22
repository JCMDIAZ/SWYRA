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
    public partial class FrmMenuGuia : Form
    {
        public string cvedoc;
        private Pedidos ped = new Pedidos();
        private List<DetallePedidoMerc> det = new List<DetallePedidoMerc>();

        public FrmMenuGuia()
        {
            InitializeComponent();
        }

        private void pbConcluir_Click(object sender, EventArgs e)
        {
            try
            {
                var query = "UPDATE PEDIDO SET ESTATUSPEDIDO = 'INGRESARGUIA' " +
                            "WHERE LTRIM(CVE_DOC) = '" + cvedoc + "'";
                var r = Program.GetExecute(query, 10);
                query = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " +
                        "where LTRIM(CVE_DOC) = '" + cvedoc + "' " +
                        "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values (" +
                        "@cvedoc, 'INGRESARGUIA', getdate(), '" + Program.usActivo.Usuario + "')";
                r = Program.GetExecute(query, 11);
                MessageBox.Show(@"Guardado satisfactoriamente.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
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
            try
            {
                var str = txtCodigo.Text;
                txtCodigo.Text = "";
                var d = det.Find(o => o.codigo_barra == str);
                if (d == null && lblGuia.Text == "")
                {
                    lblGuia.Text = str;
                }
                else if (d == null && lblGuia.Text != str)
                {
                    MessageBox.Show("Paquete inexistente favor de confirmar.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    lblGuia.Text = "";
                }
                else if (d != null && lblGuia.Text != str)
                {
                    DialogResult dr = DialogResult.OK;
                    if(d.num_guia != "")
                    {
                        FrmGuia2 frmConf1 = new FrmGuia2();
                        dr = frmConf1.ShowDialog();
                        frmConf1.Close();
                    }
                    if (dr == DialogResult.OK)
                    {
                        d.num_guia = lblGuia.Text;
                        lblGuia.Text = "";
                        var query = "UPDATE DETALLEPEDIDOMERC SET NUM_GUIA = '" + d.num_guia + 
                            "' WHERE LTRIM(CVE_DOC) = '" + cvedoc + "' AND CONSEC = " + d.consec;
                        var res = Program.GetExecute(query, 3);
                        det = CargaDetalleMerc();
                    }
                }
                dgDetPedidos.DataSource = Program.ToDataTable<DetallePedidoMerc>(det, "detallePedidoMerc");
                pbConcluir.Visible = (det.Where(o => o.num_guia == "").ToList().Count == 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            txtCodigo.Focus();
            cambiaLeyenda();
        }

        private void dgPedidos_CurrentCellChanged(object sender, EventArgs e)
        {
            dgDetPedidos.Select(dgDetPedidos.CurrentRowIndex);
            txtCodigo.Focus();
        }

        private void FrmMenuGuia_Load(object sender, EventArgs e)
        {
            var query = "select LTRIM(CVE_DOC) CVE_DOC, LTRIM(CVE_CLPV) CVE_CLPV, c.NOMBRE Cliente, LTRIM(p.CVE_VEND) CVE_VEND, " +
                        "TIPOSERVICIO, PRIORIDAD, ISNULL(SOLAREA,0) SOLAREA, ESTATUSPEDIDO, IMPORTE, CONTADO " +
                        "from PEDIDO p join CLIENTE c on p.CVE_CLPV = c.CLAVE WHERE LTRIM(CVE_DOC) = '" + cvedoc + "'";
            ped = Program.GetDataTable(query, 2).ToData<Pedidos>();
            lblPedido.Text = ped.cve_doc;
            lblCliente.Text = ped.cliente;
            lblGuia.Text = "";
            lblContado.Visible = (ped.contado == "S" || ped.contado == "C");
            det = CargaDetalleMerc();
            dgDetPedidos.DataSource = Program.ToDataTable<DetallePedidoMerc>(det, "detallePedidoMerc");
            pbConcluir.Visible = (det.Where(o => o.num_guia == "").ToList().Count == 0);
            cambiaLeyenda();
            txtCodigo.Focus();
        }

        private void cambiaLeyenda()
        {
            lbl1.Visible = (lblGuia.Text == "");
            lbl2.Visible = (lblGuia.Text != "");
        }

        private List<DetallePedidoMerc> CargaDetalleMerc()
        {
            List<DetallePedidoMerc> tmp = new List<DetallePedidoMerc>();
            try
            {
                var query = "SELECT CONSEC, CODIGO_BARRA, TIPOPAQUETE, ISNULL(NUM_GUIA,'') NUM_GUIA FROM DETALLEPEDIDOMERC " +
                            "WHERE LTRIM(CVE_DOC) = '" + cvedoc + "' " +
                            "AND ISNULL(TIPOPAQUETE,'') NOT IN ('', 'GUIA') AND ISNULL(CONSEC_PADRE, 0) = 0 " +
                            "AND ISNULL(CANCELADO,0) = 0 ORDER BY CONSEC";
                tmp = Program.GetDataTable(query, 1).ToList<DetallePedidoMerc>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return tmp;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                var index = dgDetPedidos.CurrentRowIndex;
                var codigo = dgDetPedidos[index, 1].ToString();
                var d = det.Find(o => o.codigo_barra == codigo);
                d.num_guia = "";
                var query = "UPDATE DETALLEPEDIDOMERC SET NUM_GUIA = NULL " +
                    "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "' AND CODIGO_BARRA = '" + codigo + "'";
                var res = Program.GetExecute(query, 3);
                dgDetPedidos.DataSource = Program.ToDataTable<DetallePedidoMerc>(det, "detallePedidoMerc");
                pbConcluir.Visible = (det.Where(o => o.num_guia == "").ToList().Count == 0);
                txtCodigo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pbDetener_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDetenerPed frmDetenerPed = new FrmDetenerPed();
                frmDetenerPed.lblPedido.Text = ped.cve_doc.Trim();
                var rs = frmDetenerPed.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    FrmDetenerPedCausa frmCausa = new FrmDetenerPedCausa();
                    frmCausa.lblPedido.Text = ped.cve_doc.Trim();
                    frmCausa.ShowDialog();
                    var query = "UPDATE PEDIDO SET ESTATUSPEDIDO = 'DETENIDO GUIA', " +
                                "CAUSADETENIDO = '" + frmCausa.txtCausa.Text + "' " +
                                "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "'";
                    var r = Program.GetExecute(query, 6);
                    query = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " +
                            "where LTRIM(CVE_DOC) = '" + ped.cve_doc + "' " +
                            "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values (" +
                            "@cvedoc, 'DETENIDO GUIA', getdate(), '" + Program.usActivo.Usuario + "')";
                    r = Program.GetExecute(query, 7);
                    MessageBox.Show(@"Guardado satisfactoriamente.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                    frmDetenerPed.Close();
                    Close();
                }
                else
                {
                    frmDetenerPed.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}