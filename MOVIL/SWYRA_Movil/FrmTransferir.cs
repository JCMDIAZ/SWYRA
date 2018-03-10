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
    public partial class FrmTransferir : Form
    {
        public FrmTransferir()
        {
            InitializeComponent();
        }

        private void FrmTransferir_Load(object sender, EventArgs e)
        {
            try
            {
                var query = "select Usuario, Nombre from USUARIOS " +
                            "where Categoria in ('MASTER', 'SURTIDOR') AND Usuario <> '" + Program.usActivo.Usuario + "' " +
                            "ORDER BY Nombre";
                cbUsuarios.DataSource = Program.GetDataTable(query, 1).ToList<Usuarios>();
                cbUsuarios.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }
    }
}