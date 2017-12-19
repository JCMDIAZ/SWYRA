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
    public partial class FrmCambiaContraseña : Form
    {
        public Usuarios userActivo = new Usuarios();

        public FrmCambiaContraseña()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void limpiar()
        {
            Txtapass.Text = "";
            Txtnpass.Text = "";
            Txtcpass.Text = "";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var query = @"";
                if (userActivo.Password == Txtapass.Text)
                {
                    if (Txtnpass.Text == Txtcpass.Text)
                    {
                        query = @"";
                        query =
                            @"UPDATE USUARIOS SET Contraseña = ENCRYPTBYPASSPHRASE('swyra', '" + Txtcpass.Text + "')" +
                            " WHERE Usuario = " + userActivo.Usuario;
                        var res = GetExecute("DB", query, 1);
                        MessageBox.Show(@"Contraseña modificada con exito");
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show(@"La contraeña nueva no coincide con la confirmación");
                    }
                }
                else
                {
                    MessageBox.Show(@"Contraseña anterior es invalida");
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message);
            }
        }

        private void FrmCambiaContraseña_Load(object sender, EventArgs e)
        {
            TxtUsuario.Text = userActivo.Usuario + " - " + userActivo.Nombre;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
