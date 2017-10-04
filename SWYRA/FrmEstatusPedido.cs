using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Filtering.Templates;

namespace SWYRA
{
    public partial class FrmEstatusPedido : Form
    {
        private bool sw = true;
        private List<Pedidos> listPedidos = new List<Pedidos>();

        public FrmEstatusPedido()
        {
            InitializeComponent();
        }

        private void txtFechIni_TextChanged(object sender, EventArgs e)
        {
            if (sw)
            {
                sw = !sw;
                if (txtFechFin.Text == "")
                {
                    txtFechFin.DateTime = txtFechIni.DateTime.AddDays(1);
                }
                else if (txtFechFin.DateTime < txtFechIni.DateTime)
                {
                    txtFechFin.DateTime = txtFechIni.DateTime.AddDays(1);
                }
                sw = !sw;}
        }

        private void txtFechFin_TextChanged(object sender, EventArgs e)
        {
            if (sw)
            {
                txtFechIni.DateTime = txtFechFin.DateTime.AddDays(-1);
            }
            else if (txtFechIni.DateTime < txtFechFin.DateTime)
            {
                txtFechIni.DateTime = txtFechFin.DateTime.AddDays(-1);
            }
        }

        private void FrmEstatusPedido_Load(object sender, EventArgs e)
        {
            limpiarFiltro();
            validaFiltro();
        }

        private void limpiarFiltro()
        {
            cbEstatusPed.SelectedIndex = -1;
            txtFechIni.Text = "";
            txtFechFin.Text = "";
        }

        private void validaFiltro()
        {
            cbEstatusPed.Enabled = !chkActual.Checked;
            txtFechIni.Enabled = !chkActual.Checked;
            txtFechFin.Enabled = !chkActual.Checked;
        }
    }
}
