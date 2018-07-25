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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ejecuta()
        {
            if (valida())
            {
                try
                {
                    var query = "select top 1 Usuario, Nombre, Categoria, " +
                                "cast(DECRYPTBYPASSPHRASE('swyra',[Contraseña]) as varchar(15)) Password, " +
                                "Activo, [ID_StatusPermisosUser] IDStatusPermisosUser " +
                                "from usuarios where usuario = '" + txtUsuario.Text + "' ";
                    List<Usuarios> us = Program.GetDataTable(query, 1).ToList<Usuarios>();
                    if (us.Count == 0)
                    {
                        MessageBox.Show(@"El usuario no existe.");
                    }
                    else if (us.FirstOrDefault().Password != txtPassword.Text)
                    {
                        MessageBox.Show(@"La contraseña es incorrecta.");
                    }
                    else if (!us.FirstOrDefault().Activo)
                    {
                        MessageBox.Show(@"Usuario no activo. Favor de verificarlo con el Administrador");
                    }
                    else
                    {
                        Program.usActivo = us.FirstOrDefault();
                        FrmMenuPrincipal frMenuPrincipal = new FrmMenuPrincipal();
                        frMenuPrincipal.Show();
                        Hide();
                    }
                }
                catch (Exception ms)
                {
                    MessageBox.Show(ms.Message, "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ejecuta();
        }

        private bool valida() 
        {
            bool b = true;
            if (txtUsuario.Text == "")
            {
                MessageBox.Show(@"Favor de ingresar un usuario", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtUsuario.Focus();
                b = false;
            }
            else if (txtPassword.Text == "")
            {
                MessageBox.Show(@"Favor de ingresar la contraseña", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                txtUsuario.Focus();
                b = false;
            }
            return b;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Return))
            {
                ejecuta();
                e.Handled = true;
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Return))
            {
                txtPassword.Focus();
                e.Handled = true;
            }
        }
    }
}