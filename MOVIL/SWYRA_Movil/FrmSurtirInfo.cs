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
    public partial class FrmSurtirInfo : Form
    {
        public Pedidos ped = new Pedidos();

        public FrmSurtirInfo()
        {
            InitializeComponent();
        }

        private void pbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmSurtirInfo_Load(object sender, EventArgs e)
        {
            lblPedido.Text = ped.cve_doc.Trim();
            lblCliente.Text = ped.cliente;
            txtIndicacion.Text = ped.indicaciones;
            txtObservacion.Text = ped.observaciones;
            txtComentario.Text = ped.condicion;
        }
    }
}