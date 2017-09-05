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
            GetGridEmpleados();
            cbCategoria.DataSource = CargaPerfil();
        }

        private void GetGridEmpleados()
        {
            if (DGUsuarios.Rows.Count > 0)
            {
                var usuarioID = DGUsuarios.CurrentRow.Cells[0].Value;
                cargaDatos(usuarioID.ToString());
            }
            else
            {
                limpiar();
            }
        }

        private List<Usuarios> CargaEmpleados()
        {
            List<Usuarios> listEmpleados = new List<Usuarios>();
            try
            {
                var query = "SELECT Usuario, Nombre, Categoria, Activo, cast(DECRYPTBYPASSPHRASE('swyra',[Contraseña]) as varchar(15)) Password FROM Usuarios ORDER BY Usuario";
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

        private List<UsuarioAlmacen> CargaAlmacenes()
        {
            List<UsuarioAlmacen> listAlmacenes = new List<UsuarioAlmacen>();
            try
            {
                var query = "select '0' usuarios, Clave almacen, nombre from ALMACENES";
                listAlmacenes = GetDataTable("DB", query, 16).ToList<UsuarioAlmacen>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listAlmacenes;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            limpiar();
            List<Usuarios> listEmpleados = CargaEmpleados().Where(o => o.Nombre.Contains(TBoxBuscaUsua.Text) || o.Usuario.Contains(TBoxBuscaUsua.Text)).ToList();
            DGUsuarios.DataSource = listEmpleados;
            GetGridEmpleados();
        }

        private void DGUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var usuarioID = DGUsuarios.Rows[e.RowIndex].Cells[0].Value;
            cargaDatos(usuarioID.ToString());
        }

        private void cargaDatos(string usuarioID)
        {
            Usuarios empleado = CargaEmpleados().Where(o => o.Usuario == usuarioID.ToString()).First();

            TxtCodigo.Text = empleado.Usuario;
            TxtNombre.Text = empleado.Nombre;
            Txtpass.Text = empleado.Password;
            Txtcpass.Text = empleado.Password;
            cbCategoria.Text = empleado.Categoria;
            Chkact.Checked = empleado.Activo;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            TxtCodigo.Text = "";
            TxtNombre.Text = "";
            Txtpass.Text = "";
            Txtcpass.Text = "";
            cbCategoria.Text = "";
            Chkact.Checked = false;
        }
    }
}
