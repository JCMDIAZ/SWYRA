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
        List<UsuarioAlmacen> listAlmacen = new List<UsuarioAlmacen>();
        List<UsuarioAlmacen> listUsuarioAlmacen = new List<UsuarioAlmacen>();

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
            listAlmacen = CargaAlmacenes();
            lstAlmacen.DataSource = listAlmacen;
            GetGridEmpleados();
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
                var query = "select '0' usuario, Clave almacen, nombre from ALMACENES";
                listAlmacenes = GetDataTable("DB", query, 16).ToList<UsuarioAlmacen>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listAlmacenes;
        }

        private List<UsuarioAlmacen> CargaUsuarioAlmacenes(string usuario)
        {
            List<UsuarioAlmacen> listAlmacenes = new List<UsuarioAlmacen>();
            try
            {
                var query = "select u.usuario, u.almacen, a.Nombre from USUARIOS_ALMACEN u join ALMACENES a on u.almacen = a.Clave " +
                            "where u.usuario = " + usuario;
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

            listUsuarioAlmacen = CargaUsuarioAlmacenes(empleado.Usuario);
            ActualizaAlmacen();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void ActualizaAlmacen()
        {
            var listUsrIdenticos = listAlmacen.Where(o => listUsuarioAlmacen.Any(p => o.almacen == p.almacen)).ToList();
            var listUsrDif = listAlmacen.Except(listUsrIdenticos).ToList();
            var listUsrAsg = listUsuarioAlmacen.ToList();

            lstAlmacen.DataSource = listUsrDif;
            lstAlamcenAsignado.DataSource = listUsrAsg;
        }

        private void limpiar()
        {
            TxtCodigo.Text = "";
            TxtNombre.Text = "";
            Txtpass.Text = "";
            Txtcpass.Text = "";
            cbCategoria.Text = "";
            Chkact.Checked = true;

            lstAlmacen.DataSource = listAlmacen;
            var listUsrAsg = new List<UsuarioAlmacen>();
            lstAlamcenAsignado.DataSource = listUsrAsg;
            listUsuarioAlmacen = listUsrAsg;

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (lstAlmacen.Items.Count > 0)
            {
                var alm = lstAlmacen.Text;
                UsuarioAlmacen usralm = listAlmacen.Find(o => o.nombre == alm.ToString());
                listUsuarioAlmacen.Add(usralm);
                ActualizaAlmacen();
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            if (lstAlamcenAsignado.Items.Count > 0)
            {
                var alm = lstAlamcenAsignado.Text;
                UsuarioAlmacen usralm = listUsuarioAlmacen.Find(o => o.nombre == alm.ToString());
                listUsuarioAlmacen.Remove(usralm);
                ActualizaAlmacen();
            }
        }

        class Variables
        {
            public string Id { get; set; }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validaDatos())
            {
                try
                {
                    var query = @"";
                    if (TxtCodigo.Text == "")
                    {
                        Variables var1 =
                            GetDataTable("DB",
                                @"select cast((isnull(max(cast(Usuario as int)),0) + 1) as varchar(5)) Id from USUARIOS where Usuario <> '9999'",
                                17).ToData<Variables>();
                        TxtCodigo.Text = var1.Id;
                        query =
                            @"INSERT USUARIOS (Usuario, Nombre, Categoria, Contraseña, Activo) " +
                            "VALUES ('" + var1.Id + "', '" + TxtNombre.Text + "', '" + cbCategoria.Text + "', ENCRYPTBYPASSPHRASE('swyra', '" + Txtpass.Text +
                            "'), " + ((Chkact.Checked) ? "1" : "0") + ")";
                    }
                    else
                    {
                        query =
                            @"UPDATE USUARIOS SET Nombre = '" + TxtNombre.Text + "', Categoria = '" + cbCategoria.Text + "', " +
                            "Contraseña = ENCRYPTBYPASSPHRASE('swyra', '" + Txtpass.Text + "') , Activo = " + ((Chkact.Checked) ? "1" : "0") +
                            " WHERE Usuario = " + TxtCodigo.Text;
                    }
                    var res = GetExecute("DB", query, 17);
                    if (res)
                    {
                        var query2 = "delete USUARIOS_ALMACEN where usuario = '" + TxtCodigo.Text + "' ";
                        foreach (var usrAlm in listUsuarioAlmacen)
                        {
                            query2 += "insert USUARIOS_ALMACEN (usuario, almacen) values ('" + TxtCodigo.Text + "', '" + usrAlm.almacen + "') ";
                        }
                        GetExecute("DB", query2, 18);
                    }
                    MessageBox.Show(@"Guardado satisfactoriamente.");
                    DGUsuarios.DataSource = CargaEmpleados();
                    GetGridEmpleados();
                }
                catch (Exception ms)
                {
                    MessageBox.Show(ms.Message);
                }
            }
        }

        private bool validaDatos()
        {
            bool b = true;
            if (TxtNombre.Text == "")
            {
                MessageBox.Show(@"Favor de agregar el nombre del usuario.");
                TxtNombre.Focus();
                b = false;
            }
            if (Txtpass.Text == "")
            {
                MessageBox.Show(@"Favor de asignar password del usuario");
                Txtpass.Focus();
                b = false;
            }
            if (Txtcpass.Text == "")
            {
                MessageBox.Show(@"Favor de asignar la confirmación del password.");
                Txtcpass.Focus();
                b = false;
            }
            if (cbCategoria.Text == "")
            {
                MessageBox.Show(@"Favor de seleccionar la categoría del usuario.");
                cbCategoria.Focus();
                b = false;
            }
            if (Txtpass.Text != Txtcpass.Text)
            {
                MessageBox.Show(@"El password no coincide con la confirmación del password. Favor de validar.");
                Txtpass.Focus();
                b = false;
            }
            if (lstAlamcenAsignado.Items.Count == 0)
            {
                MessageBox.Show(@"Favor de asignarle al menos un almacen.");
                lstAlmacen.Focus();
                b = false;
            }
            return b;
        }
    }
}
