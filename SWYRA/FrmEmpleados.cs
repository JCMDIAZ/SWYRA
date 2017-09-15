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
        List<Perfil> listPerfil = new List<Perfil>();
        List<Areas> listAreas = new List<Areas>(); 

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
            listAreas = CargaAreas();
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
                var query = "SELECT Usuario, Nombre, Categoria, Activo, cast(DECRYPTBYPASSPHRASE('swyra',[Contraseña]) as varchar(15)) Password, LetraERP, AreaAsignada FROM Usuarios ORDER BY Usuario";
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

        private List<Areas> CargaAreas()
        {
            List<Areas> listAreas = new List<Areas>();
            try
            {
                var query = "SELECT AREAID, NOMBRE, DESCRIPCION, ALMACEN, UBICACION, AREAM2, ALTURA, ACTIVO FROM AREAS";
                listAreas = GetDataTable("DB", query, 16).ToList<Areas>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return listAreas;
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
            cbCategoria.Text = empleado.Categoria.TrimEnd();
            Chkact.Checked = empleado.Activo;

            txtLetra.Text = empleado.LetraERP;
            txtLetra.Enabled = (cbCategoria.Text == @"COBRADOR");

            cbArea.Text = empleado.AreaAsignada;
            cbArea.Enabled = (cbCategoria.Text == @"SURTIDOR" || cbCategoria.Text == @"EMPAQUETADOR");

            listUsuarioAlmacen = CargaUsuarioAlmacenes(empleado.Usuario);
            ActualizaAlmacen();
            ViewModulo();
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

            lstAlmacen.DataSource = listUsrDif;lstAlamcenAsignado.DataSource = listUsrAsg;

            var listAreasAsig = listAreas.Where(o => listUsrAsg.Any(p => p.almacen == o.areaid)).ToList();
            cbArea.Properties.DataSource = listAreasAsig;
            habilitaCampos();}

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

            habilitaCampos();
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
                            @"INSERT USUARIOS (Usuario, Nombre, Categoria, Contraseña, Activo, LetraERP, AreaAsignada) " +
                            "VALUES (RIGHT('0000" + var1.Id + "',4), '" + TxtNombre.Text + "', '" + cbCategoria.Text + "', ENCRYPTBYPASSPHRASE('swyra', '" + Txtpass.Text +
                            "'), " + ((Chkact.Checked) ? "1" : "0") + ", " + ((txtLetra.Enabled) ? "'" + txtLetra.Text + "'": "Null") + 
                            ", " + ((cbArea.Enabled) ? "'" + cbArea.Text + "'" : "Null") + ")";
                    }
                    else
                    {
                        query =
                            @"UPDATE USUARIOS SET Nombre = '" + TxtNombre.Text + "', Categoria = '" + cbCategoria.Text + "', " +
                            "Contraseña = ENCRYPTBYPASSPHRASE('swyra', '" + Txtpass.Text + "') , Activo = " + ((Chkact.Checked) ? "1" : "0") +
                            ", LetraERP = " + ((txtLetra.Enabled) ? "'" + txtLetra.Text + "'" : "Null") +
                            ", AreaAsignada = " + ((cbArea.Enabled) ? "'" + cbArea.Text + "'" : "Null") +
                            " WHERE Usuario = " + TxtCodigo.Text;
                    }
                    var res = GetExecute("DB", query, 17);
                    if (res)
                    {
                        var query2 = "delete USUARIOS_ALMACEN where usuario = '" + TxtCodigo.Text + "' ";
                        foreach (var usrAlm in listUsuarioAlmacen)
                        {
                            query2 += "insert USUARIOS_ALMACEN (usuario, almacen) values (RIGHT('0000" + TxtCodigo.Text + "',4), RIGHT('0000" + usrAlm.almacen + "',4)) ";
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
            else if (Txtpass.Text == "")
            {
                MessageBox.Show(@"Favor de asignar password del usuario");
                Txtpass.Focus();
                b = false;
            }
            else if (Txtcpass.Text == "")
            {
                MessageBox.Show(@"Favor de asignar la confirmación del password.");
                Txtcpass.Focus();
                b = false;
            }
            else if (cbCategoria.Text == "")
            {
                MessageBox.Show(@"Favor de seleccionar la categoría del usuario.");
                cbCategoria.Focus();
                b = false;
            }
            else if (Txtpass.Text != Txtcpass.Text)
            {
                MessageBox.Show(@"El password no coincide con la confirmación del password. Favor de validar.");
                Txtpass.Focus();
                b = false;
            }
            else if (lstAlamcenAsignado.Items.Count == 0)
            {
                MessageBox.Show(@"Favor de asignarle al menos un almacen.");
                lstAlmacen.Focus();
                b = false;
            }
            else if (txtLetra.Enabled && txtLetra.Text == "")
            {
                MessageBox.Show(@"Favor de asignarle una letra clave al Cobrador.");
                txtLetra.Focus();
                b = false;
            }
            else if (cbArea.Enabled && cbArea.Text == "")
            {
                MessageBox.Show(@"Favor de seleccionar un Área al Surtidor o Empaquetador.");
                cbArea.Focus();
                b = false;
            }
            return b;
        }

        private void cbCategoria_SelectedValueChanged(object sender, EventArgs e)
        {
            ViewModulo();
            habilitaCampos();
        }

        private void habilitaCampos()
        {
            txtLetra.Text = "";
            txtLetra.Enabled = (cbCategoria.Text == @"COBRADOR");

            cbArea.EditValue = null;
            cbArea.Enabled = (cbCategoria.Text == @"SURTIDOR" || cbCategoria.Text == @"EMPAQUETADOR");
        }

        private void ViewModulo()
        {
            if (cbCategoria.Text != "")
            {
                var perfil = listPerfil.FirstOrDefault(o => o.descripcion == cbCategoria.Text.TrimEnd());
                label9.Text = perfil.modulo;
            }
            else
            {
                label9.Text = "";
            }
        }

        private void txtLetra_TextChanged(object sender, EventArgs e)
        {
            txtLetra.Text = txtLetra.Text.ToUpper();
        }
    }
}
