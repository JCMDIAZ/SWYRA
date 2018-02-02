using System;
using System.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;
using System.Configuration;
using static SWYRA.General;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace SWYRA
{
    public partial class MDIPrincipal : Form
    {
        // Set the ServerType to 1 for connect to the embedded server
        public Usuarios userActivo = new Usuarios();

        //public string connectionString = @"User=SYSDBA; Password=masterkey; Database=C:\BASE\Ejemplos.fdb; DataSource=localhost; Port=3050; Dialect=3; Charset=NONE; Role=; Connection lifetime=15; Pooling=true; Packet Size=8192; ServerType=0";

        private int time1;

        public MDIPrincipal()
        {
            string provider = "DataProtectionConfigurationProvider";
            string strConn = "Data Source=" + ConfigurationManager.AppSettings["sqlServer1"].ToString() + ";Initial Catalog=SWYRA;Persist Security Info=True;User ID=swrya_Cliente;Password=swyra2017";
            ConnectionStringSettings setConn = new ConnectionStringSettings("DB", strConn, "System.Data.SqlClient");
            string strFbConn = @"User = SYSDBA; Password = masterkey; Database =" + ConfigurationManager.AppSettings["fbDataBase1"].ToString() + 
                                "; DataSource = " + ConfigurationManager.AppSettings["fbServer1"].ToString() + 
                                "; Port = 3050; Dialect = 3; Charset = NONE; Role =; Connection lifetime = 15; Pooling = true; Packet Size = 8192; ServerType = 0";
            ConnectionStringSettings setFbConn = new ConnectionStringSettings("FB", strFbConn, "FirebirdSql.Data.FirebirdClient");

            Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            appConfig.ConnectionStrings.ConnectionStrings.Add(setConn);
            appConfig.ConnectionStrings.ConnectionStrings.Add(setFbConn);
            ConfigurationSection connStrings = appConfig.ConnectionStrings;

            connStrings.SectionInformation.ProtectSection(provider);
            connStrings.SectionInformation.ForceSave = true;
            appConfig.Save(ConfigurationSaveMode.Full);

            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void MDIPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                Usuarios usr = GetDataTable("DB", "select top 1 * from USUARIOS", 0).ToData<Usuarios>();
                //Actividad act = GetFbDataTable("FB", "select * from ACTIVI01", -1).ToData<Actividad>();
                time1 = 1;

                if (!validaActivacion())
                {
                    var fAct = new FrmActivacion();
                    fAct.clave = getUniqueID("C");
                    fAct.ShowDialog();
                    fAct.Close();
                }

                var fLog = new FrmLogin();
                fLog.TxtUser.Focus();
                fLog.ShowDialog();

                userActivo = fLog.usActivo;
                toolStripStatusLabel1.Text = @"Usuario: " + userActivo.Nombre.ToUpper();
                fLog.Close();
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message.ToString());
                Application.Exit();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool validaActivacion()
        {
            bool b = false;
            try
            {
                var pass = getUniqueID("C");
                var query = "SELECT [ID_RegMach] IdRegMach, cast(DECRYPTBYPASSPHRASE('swyra',[Macmach_RegMach]) as varchar(8000)) MacmachRegMach, " +
                            "[Fecha_RegMach] FechaRegMach, [Activo_RegMach] ActivoRegMach FROM[dbo].[Cat_RegMach] " +
                            "where cast(DECRYPTBYPASSPHRASE('swyra',[Macmach_RegMach]) as varchar(8000)) like '%" + pass + "%' " +
                            "and Activo_RegMach = 1";
                List<CatRegMach> catRegMaches = GetDataTable("DB", query, 2).ToList<CatRegMach>();
                b = (catRegMaches.Count > 0);
                if (b)
                {
                    var reg = catRegMaches.FirstOrDefault();
                    var str = reg.MacmachRegMach.Split('|');
                    if (str.Length > 1)
                    {
                        var fch = DateTime.ParseExact(str[1], "yyyyMMdd", CultureInfo.InvariantCulture);
                        b = (DateTime.Now < fch);
                        if (!b)
                        {
                            MessageBox.Show(@"Se agoto el tiempo de prueba. Consulta a tu Ejecutivo de Ventas VISIONTEC");
                        }
                    }
                }}
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message.ToString());
                b = false;
            }
            return b;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fTest = new Test();
            fTest.ShowDialog();
            fTest.Close();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fEmpl = new FrmEmpleados();
            fEmpl.ShowDialog();
            fEmpl.Close();
        }

        private void almacenesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fDeptos = new FrmDeptos();
            fDeptos.ShowDialog();
            fDeptos.Close();
        }

        private void áreasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fAreas = new FrmAreas();
            fAreas.ShowDialog();
            fAreas.Close();
        }

        private void estatusPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fEstPed = new FrmEstatusPedido();
            fEstPed.userActivo = userActivo;
            fEstPed.ShowDialog();
            fEstPed.Close();
        }

        private void autorizaciónPedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fAutPed = new FrmAutorizaCobro();
            fAutPed.userActivo = userActivo;
            fAutPed.ShowDialog();
            fAutPed.Close();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fCamCon = new FrmCambiaContraseña();
            fCamCon.userActivo = userActivo;
            fCamCon.ShowDialog();
            userActivo.Password = fCamCon.Txtcpass.Text;
            fCamCon.Close();
        }

        private void remisiónDePedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fRemision = new FrmRemision();
            fRemision.ShowDialog();
            fRemision.Close();
        }

        private void mínimosYMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fPresentProd = new FrmPresentProd();
            fPresentProd.ShowDialog();
            fPresentProd.Close();
        }

        private void condicionesDeProdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fCondicion= new FrmCondiciones();
            fCondicion.ShowDialog();
            fCondicion.Close();
        }
    }
}