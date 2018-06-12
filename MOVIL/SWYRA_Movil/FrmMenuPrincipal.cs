using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace SWYRA_Movil
{
    public partial class FrmMenuPrincipal : Form
    {
        private List<Pedidos> listPedidos = new List<Pedidos>();

        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            string[] surt = { "MASTER", "SURTIDOR" };
            string[] empq = { "MASTER", "EMPAQUETADOR" };
            string[] guia = { "MASTER", "ETIQUETADOR GUIA" };
            pnlImpCod.Visible = (Program.usActivo.Categoria.Trim().In(surt));
            pnlPedidos.Visible = (Program.usActivo.Categoria.Trim().In(surt));
            pnlSurtido.Visible = (Program.usActivo.Categoria.Trim().In(surt));
            pnlEmpaque.Visible = (Program.usActivo.Categoria.Trim().In(empq) && Program.usActivo.AreaAsignada != "GENERAL");
            pnlGuías.Visible = (Program.usActivo.Categoria.Trim().In(guia));
            CuentaPedidos();
            timer1.Enabled = true;
        }

        private void pnlImpCod_Click(object sender, EventArgs e)
        {
            FrmImpCodigoBarra frmImpCod = new FrmImpCodigoBarra();
            frmImpCod.Show();
        }

        private void pnlPedidos_Click(object sender, EventArgs e)
        {
            FrmPedidos frmPed = new FrmPedidos();
            frmPed.Show();
        }

        private void pnlSurtido_Click(object sender, EventArgs e)
        {
            FrmPedidosArea frmPedA = new FrmPedidosArea();
            frmPedA.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CuentaPedidos();
        }

        private void CuentaPedidos()
        {
            try
            {
                var query = "select ESTATUSPEDIDO, ISNULL(SOLAREA,0) SOLAREA from PEDIDO where ESTATUSPEDIDO in ('SURTIR', 'MODIFICACION', 'DETENIDO', 'DEVOLUCION', 'EMPAQUE', 'GUIA')";
                listPedidos = Program.GetDataTable(query, 2).ToList<Pedidos>();
                string[] opc = {"SURTIR", "MODIFICACION", "DETENIDO", "DEVOLUCION"};
                var ped = listPedidos.Where(o => o.estatuspedido.In(opc) && o.solarea == false).ToList().Count.ToString();
                var are = listPedidos.Where(o => o.estatuspedido.In(opc) && o.solarea == true).ToList().Count.ToString();
                var emp = listPedidos.Where(o => o.estatuspedido == "EMPAQUE").ToList().Count.ToString();
                var lev = listPedidos.Where(o => o.estatuspedido == "GUIA").ToList().Count.ToString();
                if (lblCantPed.Text != ped || lblCantArea.Text != are || lblCantEmp.Text != emp || lblCantLev.Text != lev) { Program.Beep(); }
                lblCantPed.Text = ped;
                lblCantArea.Text = are;
                lblCantEmp.Text = emp;
                lblCantLev.Text = lev;
            }
            catch (Exception ex)
            {
                timer1.Enabled = false;
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }

        private void pnlEmpaque_Click(object sender, EventArgs e)
        {
            FrmPedidoEmpaque frmPedE = new FrmPedidoEmpaque();
            frmPedE.Show();
        }

        private void pnlGuías_Click(object sender, EventArgs e)
        {
            FrmPedidoGuia frmPedG = new FrmPedidoGuia();
            frmPedG.Show();
        }
    }
}