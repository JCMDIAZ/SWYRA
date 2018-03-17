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

        public FrmDevolucion()
        {
            InitializeComponent();
        }

        private void pbIncompleto_Click(object sender, EventArgs e)
        {

        }

        private void pbSalir_Click_1(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCodigo_LostFocus(object sender, EventArgs e)
        {

        }

        private void dgDetallePed_CurrentCellChanged(object sender, EventArgs e)
        {

        }

        private void FrmDevolucion_Load(object sender, EventArgs e)
        {

        }
    }
}