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
    public partial class FrmActivacion : Form
    {
        private Register reg = new Register();

        public FrmActivacion()
        {
            InitializeComponent();
        }

        private void FrmActivacion_Load(object sender, EventArgs e)
        {
            txtClave.Text = Program.GetDeviceID(true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                var query = "UPDATE Cat_RegMach set Activo_RegMach = 0" +
                            "where cast(DECRYPTBYPASSPHRASE('swyra',[Macmach_RegMach]) as varchar(8000)) like '%" + txtClave.Text + "%' " +
                            "INSERT Cat_RegMach (Macmach_RegMach, Fecha_RegMach, Activo_RegMach) " +
                            "VALUES(ENCRYPTBYPASSPHRASE('swyra', '" + reg.register + "'), GETDATE(), 1)";
                if (Program.GetExecute(query, 2))
                {
                    var deviceID = Program.GetDeviceID(false);
                    var queryCE = "DELETE FROM [RegMach]";
                    Program.GetCeExecute(queryCE, 3);
                    queryCE =  "INSERT INTO [RegMach] ([Macmach], [Fecha], [Activo]) " +
                               "VALUES ('" + deviceID + "', GETDATE(), 1); ";
                    if (Program.GetCeExecute(queryCE, 4))
                    {
                        MessageBox.Show(@"Activación Exitosa", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                        Form1 fr1 = new Form1();
                        fr1.Show();
                    }
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message);
            }
        }

        private void Compara()
        {
            try
            {
                btnActivar.Enabled = false;
                if (txtLlave.Text != "")
                {
                    string register = "0x01000000" + txtLlave.Text;
                    var query = "select isnull(cast(decryptbypassphrase('swyra'," + register +
                                ") as varchar(8000)),'') register";
                    reg = Program.GetDataTable(query, 1).ToData<Register>();
                    if (reg.register == "")
                    {
                        MessageBox.Show(@"Llave de activación incorrecta", "SWYRA", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                        txtLlave.Text = "";
                        txtLlave.Focus();
                    }
                    else
                    {
                        btnActivar.Enabled = true;
                        btnActivar.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtLlave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Return))
            {
                btnCancelar.Focus();
                e.Handled = true;
            }
        }

        private void txtLlave_LostFocus(object sender, EventArgs e)
        {
            if (txtLlave.Text != "")
            {
                Compara();
            }
        }
    }
}