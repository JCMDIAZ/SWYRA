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
    public partial class FrmMenuPrincipal : Form
    {
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
    }
}