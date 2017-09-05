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
            DGUsuarios.DataSource = CargaEmpleados();
            cbCategoria.DataSource = CargaPerfil();
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

        private List<Perfil> CargaPerfil()
        {
            List<Perfil> listPerfil = new List<Perfil>();
            try
            {
                var query = "SELECT ID, DESCRIPCION, MODULO FROM PERFIL ORDER BY DESCRIPCION";
                listPerfil = GetDataTable("DB", query, 15).ToList<Perfil>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listPerfil;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            List<Usuarios> listEmpleados = CargaEmpleados().Where(o => o.Nombre.Contains(TBoxBuscaUsua.Text) || o.Usuario.Contains(TBoxBuscaUsua.Text)).ToList();
            DGUsuarios.DataSource = listEmpleados;
        }
    }
}
