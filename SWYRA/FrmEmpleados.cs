using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SWYRA.General;

namespace SWYRA
{
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            List<Usuarios> listEmpleados = CargaEmpleados();
            DGUsuarios.DataSource = listEmpleados;
        }

        private List<Usuarios> CargaEmpleados()
        {
            List<Usuarios> listEmpleados = new List<Usuarios>();
            try
            {
                var query = "SELECT Usuario, Nombre, Categoria, Activo FROM Usuarios ORDER BY Usuario";
                listEmpleados = GetDataTable("DB", query, 14).ToList<Usuarios>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listEmpleados;
        } 
    }
}
