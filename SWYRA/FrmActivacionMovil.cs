using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SWYRA
{
    public partial class FrmActivacionMovil : Form
    {
        public FrmActivacionMovil()
        {
            InitializeComponent();
        }

        private void meDatos_EditValueChanged(object sender, EventArgs e)
        {
            barCodeControl1.Text = meDatos.Text;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void meDatos_Enter(object sender, EventArgs e)
        {
            barCodeControl1.Text = meDatos.Text;
        }
    }
}
