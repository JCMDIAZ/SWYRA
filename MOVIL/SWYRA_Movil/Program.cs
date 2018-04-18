using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Globalization;
using System.ComponentModel;

namespace SWYRA_Movil
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            try
            {
                var deviceID = GetDeviceID(false);
                CatRegMachCE dv = GetCeDataTable("SELECT [Id], [Macmach], [Fecha], [Activo] FROM [RegMach]", 1).ToData<CatRegMachCE>();
                if (dv == null || dv.Macmach != deviceID)
                {
                    var cn = GetConnection();
                    if (cn.State == ConnectionState.Open)
                    {
                        CloseConnection(cn);
                        Application.Run(new FrmActivacion());
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    if (validaActivacion(dv.Activo))
                    {
                        
                        Application.Run(new Form1());
                    }
                    else
                    {
                        Application.Run(new FrmActivacion());
                    }
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message, "ERROR DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        public static Usuarios usActivo = new Usuarios();

        private static bool validaActivacion(bool act)
        {
            bool b = false;
            try
            {
                if (act)
                {
                    var pass = GetDeviceID(true);
                    var query = "SELECT [ID_RegMach] IdRegMach, cast(DECRYPTBYPASSPHRASE('swyra',[Macmach_RegMach]) as varchar(8000)) MacmachRegMach, " +
                                "[Fecha_RegMach] FechaRegMach, [Activo_RegMach] ActivoRegMach FROM[dbo].[Cat_RegMach] " +
                                "where cast(DECRYPTBYPASSPHRASE('swyra',[Macmach_RegMach]) as varchar(8000)) like '%" + pass + "%' " +
                                "and Activo_RegMach = 1";
                    List<CatRegMach> catRegMaches = GetDataTable(query, 1).ToList<CatRegMach>();
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
                                MessageBox.Show(@"Se agoto el tiempo de prueba. Consulta a tu Ejecutivo de Ventas VISIONTEC", "ERROR DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"Se agoto el tiempo de prueba. Consulta a tu Ejecutivo de Ventas VISIONTEC", "ERROR DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
            }
            catch (Exception ms)
            {
                MessageBox.Show(ms.Message.ToString());
                b = false;
            }
            return b;
        }

        public static SqlConnection GetConnection()
        {
            var Server = "";
            try
            {
                var BD = "SWYRA";
                var User1 = "swrya_Cliente";
                var PWD1 = "swyra2017";

                var directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
                StreamReader str = new StreamReader(directoryName + "\\Config.txt");
                var row = str.ReadLine().Split('=');
                if(row[0]!="SERVER"){
                    MessageBox.Show("Error de configuración, revise Config.txt","ERROR DE SISTEMA", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    Application.Exit();
                }
                Server = row[1];
                str.Close();

                var connString = "Data Source=" + Server + ";Initial Catalog=" + BD + ";Persist Security Info=True;User ID=" + User1 + ";Password=" + PWD1;
                var cn = new SqlConnection(connString);
                for (var retry = 0; retry < 3; retry++)
                {
                    try
                    {
                        cn.Open();
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (retry == 2)
                        {
                            throw new ApplicationException(ex.Message);
                        }
                        //TODO: Log error
                    }
                }
                return cn;
            }
            catch (NullReferenceException)
            {
                throw new ApplicationException(string.Format("Base de Datos SWYRA del servidor '{0}' indefinido.", Server));
            }
            catch (FormatException)
            {
                throw new ApplicationException(string.Format("Error en la definición de la base de datos SWYRA del servidor '{0}'.", Server));
            }
            catch
            {
                throw new ApplicationException(string.Format("No se pudo conectar a la base de datos SWYRA del servidor '{0}'.", Server));
            }
        }

        public static SqlCeConnection GetCeConnection()
        {
            var Server = "SWYRA";
            try
            {
                var DB = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase) + "\\" + Server + ".sdf";
                var connString = "Data Source = " + DB + "; password = V!$!=NT#C";
                var cn = new SqlCeConnection(connString);
                for (var retry = 0; retry < 3; retry++)
                {
                    try
                    {
                        cn.Open();
                        break;
                    }
                    catch (Exception ex)
                    {
                        if (retry == 2)
                        {
                            throw new ApplicationException(ex.Message);
                        }
                        //TODO: Log error
                    }
                }
                return cn;
            }
            catch (NullReferenceException)
            {
                throw new ApplicationException(string.Format("Base de Datos CE '{0}' indefinido.", Server));
            }
            catch (FormatException)
            {
                throw new ApplicationException(string.Format("Error en la definición de la base de datos CE '{0}'.", Server));
            }
            catch
            {
                throw new ApplicationException(string.Format("No se pudo conectar a la base de datos CE '{0}'.", Server));
            }
        }

        public static void CloseConnection(SqlConnection sql)
        {
            try
            {
                sql.Close();
            }
            catch { }
        }

        public static void CloseCeConnection(SqlCeConnection sql)
        {
            try
            {
                sql.Close();
            }
            catch { }
        }

        public static DataTable GetDataTable(string query, int idError)
        {
            DataTable dt = new DataTable();
            try
            {
                var sqlCon = GetConnection();
                var sqlAdt = new SqlDataAdapter(query, sqlCon);
                sqlAdt.Fill(dt);
                CloseConnection(sqlCon);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Error {0}: {1}", idError.ToString(), e.Message.ToString()));
            }
            return dt;
        }

        public static DataTable GetCeDataTable(string query, int idError)
        {
            DataTable dt = new DataTable();
            try
            {
                var sqlCon = GetCeConnection();
                var sqlAdt = new SqlCeDataAdapter(query, sqlCon);
                sqlAdt.Fill(dt);
                CloseCeConnection(sqlCon);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Error {0}: {1}", idError.ToString(), e.Message.ToString()));
            }
            return dt;
        }

        public static bool GetExecute(string query, int idError)
        {
            bool b = false;
            try
            {
                var sqlCon = GetConnection();
                var sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                b = true;
                CloseConnection(sqlCon);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Error {0}: {1}", idError.ToString(), e.Message.ToString()));
            }
            return b;
        }

        public static bool GetCeExecute(string query, int idError)
        {
            bool b = false;
            try
            {
                var sqlCon = GetCeConnection();
                var sqlCmd = new SqlCeCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                b = true;
                CloseCeConnection(sqlCon);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Error {0}: {1}", idError.ToString(), e.Message.ToString()));
            }
            return b;
        }

        [DllImport("coredll.dll")]
        private extern static int GetDeviceUniqueID([In, Out] byte[] appdata,
                                                    int cbApplictionData,
                                                    int dwDeviceIDVersion,
                                                    [In, Out] byte[] deviceIDOuput,
                                                    out uint pcbDeviceIDOutput);

        public static string GetDeviceID(bool small)
        {
            string appString = "Visiontec";
            byte[] appData = new byte[appString.Length];
            for (int count = 0; count < appString.Length; count++)
            {
                appData[count] = (byte)appString[count];
            }

            int appDataSize = appData.Length;
            byte[] DeviceOutput = new byte[20];
            uint SizeOut = 20;
            GetDeviceUniqueID(appData, appDataSize, 1, DeviceOutput, out SizeOut);

            string idString = "";
            for (int i = 0; i < DeviceOutput.Length; i++)
            {
                if (i == 4 || i == 6 || i == 8 || i == 10)
                    idString = String.Format("{0}-{1}", idString, DeviceOutput[i].ToString("x2"));
                else
                    idString = String.Format("{0}{1}", idString, DeviceOutput[i].ToString("x2"));
            }
            var dat = idString.Split('-');
            var last = dat.Length - 1;
            var res = ((small) ? @"FeR001V" + dat[last] + "T" : idString);

            return res;
        }

        public static DataTable ToDataTable<T>(IList<T> data, string tableName)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            table.TableName = tableName;
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static T GetNext<T>(IEnumerable<T> list, T current)
        {
            try
            {
                return list.SkipWhile(x => !x.Equals(current)).Skip(1).First();
            }
            catch
            {
                return default(T);
            }
        }

        public static T GetPrevious<T>(IEnumerable<T> list, T current)
        {
            try
            {
                return list.TakeWhile(x => !x.Equals(current)).Last();
            }
            catch
            {
                return default(T);
            }
        }

        [DllImport("Coredll.dll")]
        private static extern void MessageBeep(int Flags);

        /// <summary>
        /// Types of beep alerts
        /// </summary>
        public enum BeepAlert
        {
            Hand = 16,
            Question = 32,
            Exclamation = 48,
            Asterisk = 64,
        }

        /// <summary>
        /// Executes a general beep, statically
        /// </summary>
        public static void Beep()
        {
            Beep(BeepAlert.Hand);
        }

        /// <summary>
        /// Execute a the given alert
        /// </summary>
        /// <param name="alert">Type of alert</param>
        public static void Beep(BeepAlert alert)
        {
            MessageBeep((int)alert);
        }

        /// <summary>
        /// Execute an error alert
        /// </summary>
        public static void BeepError()
        {
            Beep(BeepAlert.Exclamation);
        }
    }
}