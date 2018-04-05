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
    public partial class FrmMenuPedidos : Form
    {
        public string cvedoc;
        private Pedidos ped = new Pedidos();
        private List<DetallePedidos> det = new List<DetallePedidos>();
        private List<DetallePedidos> dev = new List<DetallePedidos>();
        private List<DetallePedidos> detA = new List<DetallePedidos>();
        private List<DetallePedidos> devA = new List<DetallePedidos>();

        public FrmMenuPedidos()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMenuPedidos_Load(object sender, EventArgs e)
        {
            try
            {
                var query = "select LTRIM(CVE_DOC) CVE_DOC, LTRIM(CVE_CLPV) CVE_CLPV, c.NOMBRE Cliente, LTRIM(p.CVE_VEND) CVE_VEND, " +
                            "TIPOSERVICIO, PRIORIDAD, ISNULL(SOLAREA,0) SOLAREA, ESTATUSPEDIDO " + 
                            "from PEDIDO p join CLIENTE c on p.CVE_CLPV = c.CLAVE WHERE LTRIM(CVE_DOC) = '" + cvedoc + "'";
                ped = Program.GetDataTable(query, 1).ToData<Pedidos>();
                txtPedido.Text = ped.cve_doc;
                txtCliente.Text = "(" + ped.cve_clpv + ") " + ped.cliente;
                txtServicio.Text = ped.tiposervicio;
                txtPrioridad.Text = ped.prioridad;
                txtVendedor.Text = ped.cve_vend;

                pnlDetener.Visible = !(ped.estatuspedido.Trim() == "DETENIDO");
                pnlArea.Visible = !validaExis(true) && !ped.solarea;
                pnlConcluir.Visible = validaExis(false) && !pnlArea.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private bool validaExis(bool Area)
        {
            bool res = false;
            try
            {
                if (Area)
                {
                    detA = Program.GetDataTable(createQR(Area, false), 2).ToList<DetallePedidos>();
                    devA = Program.GetDataTable(createQR(Area, true), 3).ToList<DetallePedidos>();
                    var cdetA = detA.Where(o => o.surtido == false).ToList().Count;
                    var cdevA = devA.Where(o => o.devuelto == false).ToList().Count;
                    res = (cdetA == 0 && cdevA == 0);
                }
                else
                {
                    det = Program.GetDataTable(createQR(Area, false), 4).ToList<DetallePedidos>();
                    dev = Program.GetDataTable(createQR(Area, true), 5).ToList<DetallePedidos>();
                    var cdet = det.Where(o => o.surtido == false).ToList().Count;
                    var cdev = dev.Where(o => o.devuelto == false).ToList().Count;
                    res = (cdet == 0 && cdev == 0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            return res;
        }

        private string createQR(bool Area, bool Devuelto)
        {
            var query = "SELECT a.*, isnull(o.ORDEN,0) ORDEN FROM ( SELECT  CVE_DOC, NUM_PAR, dp.CVE_ART, CANT, ISNULL(" + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ",0) " + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ", " +
                    "ISNULL(" + (Devuelto ? "DEVUELTO" : "SURTIDO") + ",0) " + (Devuelto ? "DEVUELTO" : "SURTIDO") + ", i.DESCR, i.EXIST, i.LIN_PROD, " +
                    "ISNULL(ic.COMENTARIO,'') COMENTARIO, ISNULL(ic.APLICAEXIST,0) APLICAEXIST, " +
                    "ISNULL(ic.EXISTENCIA,0) MINEXIST, ISNULL(IC.APLICALOTE,0) APLICALOTE, i.CTRL_ALM, i.MASTERS_UBI, " +
                    "case when CANT -  ISNULL(" + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ",0) > i.MASTERS then " +
                    "case when isnull(i.MASTERS_UBI,'') <> '' then i.MASTERS_UBI else case when isnull(i.CTRL_ALM,'') <> '' then i.CTRL_ALM else '' END END " +
	                "else case when isnull(i.CTRL_ALM,'') <> '' then i.CTRL_ALM else '' END END ubicacion, " +
                    "CANT -  ISNULL(" + (Devuelto ? "CANTDEVUELTO" : "CANTSURTIDO") + ",0) CANTDIFERENCIA, i.UNI_EMP MIN, i.MASTERS MAS " +
                    "FROM " + (Devuelto ? "DETALLEPEDIDODEV" : "DETALLEPEDIDO") + " dp JOIN INVENTARIO i ON dp.CVE_ART = i.CVE_ART " +
                    "LEFT JOIN INVENTARIOCOND ic ON ic.CVE_ART = dp.CVE_ART AND ic.ACTIVO = 1 " +
                    "WHERE (LTRIM(CVE_DOC) = '" + ped.cve_doc + "')) AS a " +
                    "LEFT JOIN ORDEN_RUTA o ON RTRIM(LTRIM(a.ubicacion)) = o.CVE_UBI " +
                    "JOIN AREAS r ON ISNULL(o.AREA,'') " + (Area ? "" : "NOT") + " like '%' + r.NOMBRE + '%' " +
                    "ORDER BY o.ORDEN";
            return query;
        }

        private void pbImprimir_Click(object sender, EventArgs e)
        {
            FrmSurtit frmSurtir = new FrmSurtit();
            frmSurtir.ped = ped;
            frmSurtir.det = det.Where(o => o.surtido == false).ToList();
            frmSurtir.Show();
        }

        private void pbIncompletos_Click(object sender, EventArgs e)
        {
            FrmIncompleto frmIncompleto = new FrmIncompleto();
            frmIncompleto.ped = ped;
            frmIncompleto.det = det.Where(o => o.surtido == true && o.cantdiferencia > 0).ToList();
            frmIncompleto.Show();
        }

        private void pbDetenido_Click(object sender, EventArgs e)
        {
            try
            {
                FrmDetenerPed frmDetenerPed = new FrmDetenerPed();
                frmDetenerPed.lblPedido.Text = ped.cve_doc.Trim();
                var rs = frmDetenerPed.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    var query = "UPDATE PEDIDO SET ESTATUSPEDIDO = 'DETENIDO' " +
                                "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "'";
                    var r = Program.GetExecute(query, 6);
                    query = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " +
                            "where LTRIM(CVE_DOC) = '" + ped.cve_doc + "' " +
                            "insert into PEDIDO_HIST (CVE_DOC, ESTATUSPEDIDO, FECHAMOV, USUARIO) values (" +
                            "@cvedoc, 'DETENIDO', getdate(), '" + Program.usActivo.Usuario + "')";
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

        private void pbTransferir_Click(object sender, EventArgs e)
        {
            try
            {
                FrmTransferir frmTransferir = new FrmTransferir();
                frmTransferir.lblPedido.Text = ped.cve_doc.Trim();
                var rs = frmTransferir.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    var query = "UPDATE PEDIDO SET SURTIDOR_ASIGNADO = '" + frmTransferir.cbUsuarios.SelectedValue.ToString() + "' " +
                                "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "'";
                    var r = Program.GetExecute(query, 8);
                    MessageBox.Show(@"Guardado satisfactoriamente.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                    frmTransferir.Close();
                    Close();
                }
                else
                {
                    frmTransferir.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                ped.solarea = true;
                var query = "UPDATE PEDIDO SET SOLAREA = 1 " +
                            "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "'";
                var r = Program.GetExecute(query, 9);
                pnlArea.Visible = !ped.solarea;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pbConcluir_Click(object sender, EventArgs e)
        {
            try
            {
                var query = "UPDATE PEDIDO SET ESTATUSPEDIDO = '" + ((ped.estatuspedido == "DEVOLUCION") ? "CANCELACION" : "EMPAQUE") + "' " +
                            "WHERE LTRIM(CVE_DOC) = '" + ped.cve_doc + "'";
                var r = Program.GetExecute(query, 10);
                query = "declare @cvedoc varchar(20) select @cvedoc = cve_doc from PEDIDO " +
                        "where LTRIM(CVE_DOC) = '" + ped.cve_doc + "' " +
                        "insert into PEDIDO_HIST (CVE_DOC, EMO, FECHAMOV, USUARIO) values (" +
                        "@cvedoc, 'EMPAQUE', getdate(), '" + Program.usActivo.Usuario + "')";
                r = Program.GetExecute(query, 11);
                MessageBox.Show(@"Guardado satisfactoriamente.", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pbDevolucion_Click(object sender, EventArgs e)
        {
            FrmDevolucion frmDevolucion = new FrmDevolucion();
            frmDevolucion.ped = ped;
            frmDevolucion.ShowDialog();
            pnlArea.Visible = !validaExis(true) && !ped.solarea;
            pnlConcluir.Visible = validaExis(false) && !pnlArea.Visible;
        }
    }
}