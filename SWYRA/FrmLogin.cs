using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LinqToDB.Common;
using static SWYRA.General;

namespace SWYRA
{
    public partial class FrmLogin : Form
    {
        public Usuarios usActivo;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (TxtUser.Text.IsNullOrEmpty() || TxtPWD.Text.IsNullOrEmpty())
            {
                MessageBox.Show(@"Error, favor de capturar el usuario y/o contraseña");
                TxtUser.Focus();
            }
            else if (ValidaUsuario(TxtUser.Text, TxtPWD.Text))
            {
                Hide();
            }
        }

        private bool ValidaUsuario(string user, string pwd)
        {
            bool b = false;
            try
            {
                var query = "select top 1 Usuario, Nombre, Categoria, " + 
                            "cast(DECRYPTBYPASSPHRASE('swyra',[Contraseña]) as varchar(15)) Password, " +
                            "Activo, [ID_StatusPermisosUser] IDStatusPermisosUser " +
                            "from usuarios where usuario = '" + user + "' ";
                List<Usuarios> us = GetDataTable("DB", query, 1).ToList<Usuarios>();
                if (us.Count == 0)
                {
                    MessageBox.Show(@"El usuario no existe.");
                }
                else if (us.FirstOrDefault().Password != pwd)
                {
                    MessageBox.Show(@"La contraseña es incorrecta.");
                }
                else if (!us.FirstOrDefault().Activo)
                {
                    MessageBox.Show(@"Usuario no activo. Favor de verificarlo con el Administrador");
                }
                else
                { 
                    usActivo = us.FirstOrDefault();
                    b = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return b;
        }
    }
}
