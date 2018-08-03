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
    public partial class FrmEmpaqueList : Form
    {
        public Pedidos ped;
        public List<DetallePedidoMerc> det = new List<DetallePedidoMerc>();

        public FrmEmpaqueList()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmEmpaqueList_Load(object sender, EventArgs e)
        {
            lblPedido.Text = ped.cve_doc.Trim();
            dgDetallePed.DataSource = Program.ToDataTable<DetallePedidoMerc>(det, "detallePedidoMerc");
        }
    }
}