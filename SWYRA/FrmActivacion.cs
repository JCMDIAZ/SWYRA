using System;
using System.Windows.Forms;
using static SWYRA.General;
using System.Collections.Generic;

namespace SWYRA
{
    public partial class FrmActivacion : Form
    {
        public string clave;
        public string llave;
        private Register reg = new Register();

        public FrmActivacion()
        {
            InitializeComponent();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmActivacion_Load(object sender, EventArgs e)
        {
            BtnAceptar.Enabled = false;
            txtClave.Text = clave;
            txtLlave.Focus();
        }

        private void txtLlave_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BtnAceptar.Enabled = false;
                if (txtLlave.Text != "")
                {
                    string register = "0x01000000" + txtLlave.Text;
                    var query = "select isnull(cast(decryptbypassphrase('swyra'," + register +
                                ") as varchar(8000)),'') register";
                    reg = GetDataTable("DB", query, 3).ToData<Register>();
                    if (reg.register == "")
                    {
                        MessageBox.Show(@"Llave de activación incorrecta");
                        txtLlave.Text = "";
                        txtLlave.Focus();
                    }
                    else
                    {
                        BtnAceptar.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                var query = "UPDATE Cat_RegMach set Activo_RegMach = 0" +
                            "where cast(DECRYPTBYPASSPHRASE('swyra',[Macmach_RegMach]) as varchar(8000)) like '%" + reg.register + "%' " +
                            "INSERT Cat_RegMach (Macmach_RegMach, Fecha_RegMach, Activo_RegMach) " +
                            "VALUES(ENCRYPTBYPASSPHRASE('swyra', '" + reg.register + "'), GETDATE(), 1)";
                if (GetExecute("DB", query, 4))
                {
                    MessageBox.Show(@"Activación Exitosa");
                    Hide();
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message);
            }
        }
    }
}
