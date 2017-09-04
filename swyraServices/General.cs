using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using LinqToDB.SqlQuery;
using System.Management;
using System.IO;
using FirebirdSql.Data.FirebirdClient;

namespace swyraServices
{
    public static class General
    {
        public static SqlConnection GetConnection(string database)
        {
            try
            {
                var config = ConfigurationManager.ConnectionStrings[database];
                var connString = config.ConnectionString;
                //TODO: connString = Helper.Crypto.Decrypt(connString);
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
                        //TODO: Log error
                    }
                }
                return cn;
            }
            catch (NullReferenceException)
            {
                throw new ApplicationException(string.Format("Base de Datos '{0}' indefinido.", database));
            }
            catch (FormatException)
            {
                throw new ApplicationException(string.Format("Error en la definición de la base de datos '{0}'.", database));
            }
            catch
            {
                throw new ApplicationException(string.Format("No se pudo conectar a la base de datos '{0}'.", database));
            }
        }

        public static FbConnection GetFbConnection(string database)
        {
            try
            {
                var config = ConfigurationManager.ConnectionStrings[database];
                var connString = config.ConnectionString;
                //TODO: connString = Helper.Crypto.Decrypt(connString);
                var cn = new FbConnection(connString);
                for (var retry = 0; retry < 3; retry++)
                {
                    try
                    {
                        cn.Open();
                        break;
                    }
                    catch (Exception ex)
                    {
                        //TODO: Log error
                    }
                }
                return cn;
            }
            catch (NullReferenceException)
            {
                throw new ApplicationException(string.Format("Base de Datos '{0}' indefinido.", database));
            }
            catch (FormatException)
            {
                throw new ApplicationException(string.Format("Error en la definición de la base de datos '{0}'.", database));
            }
            catch
            {
                throw new ApplicationException(string.Format("No se pudo conectar a la base de datos '{0}'.", database));
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

        public static void CloseFbConnection(FbConnection sql)
        {
            try
            {
                sql.Close();
            }
            catch { }
        }

        public static DataTable GetDataTable(string db, string query, int idError)
        {
            DataTable dt = new DataTable();
            try
            {
                var sqlCon = GetConnection(db);
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

        public static DataTable GetFbDataTable(string db, string query, int idError)
        {
            DataTable dt = new DataTable();
            try
            {
                var sqlCon = GetFbConnection(db);
                var sqlAdt = new FbDataAdapter(query, sqlCon);
                sqlAdt.Fill(dt);
                CloseFbConnection(sqlCon);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Error {0}: {1}", idError.ToString(), e.Message.ToString()));
            }
            return dt;
        }

        public static bool GetExecute(string db, string query, int idError)
        {
            bool b = false;
            try
            {
                var sqlCon = GetConnection(db);
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

        public static bool GetFbExecute(string db, string query, int idError)
        {
            bool b = false;
            try
            {
                var sqlCon = GetFbConnection(db);
                var sqlCmd = new FbCommand(query, sqlCon);
                sqlCmd.ExecuteNonQuery();
                b = true;
                CloseFbConnection(sqlCon);
            }
            catch (Exception e)
            {
                throw new ApplicationException(string.Format("Error {0}: {1}", idError.ToString(), e.Message.ToString()));
            }
            return b;
        }

        public static string getUniqueID(string drive)
        {
            if (drive == string.Empty)
            {
                //Find first drive
                foreach (DriveInfo compDrive in DriveInfo.GetDrives())
                {
                    if (compDrive.IsReady)
                    {
                        drive = compDrive.RootDirectory.ToString();
                        break;
                    }
                }
            }

            if (drive.EndsWith(":\\"))
            {
                //C:\ -> C
                drive = drive.Substring(0, drive.Length - 2);
            }

            string volumeSerial = getVolumeSerial(drive);
            string cpuID = getCPUID();

            //Mix them up and remove some useless 0's
            cpuID = cpuID.Replace(":", "");
            return @"FeR001V" + cpuID.Substring(0, 4) + volumeSerial.Substring(0, 4) + cpuID.Substring(4, 4) + volumeSerial.Substring(4, 4) + cpuID.Substring(8, 4) + "T";
        }

        private static string getVolumeSerial(string drive)
        {
            ManagementObject disk = new ManagementObject(@"win32_logicaldisk.deviceid=""" + drive + @":""");
            disk.Get();

            string volumeSerial = disk["VolumeSerialNumber"].ToString();
            disk.Dispose();

            return volumeSerial;
        }

        private static string getCPUID()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_NetworkAdapterConfiguration");

            string macID = string.Empty;

            string IpEnabled, ServiceName;
            foreach (ManagementObject share in searcher.Get())
            {
                IpEnabled = share["IPEnabled"].ToString();
                ServiceName = share["ServiceName"].ToString();

                if (IpEnabled == "False" || ServiceName == "VMnetAdapter")
                    continue;
                else
                {
                    macID = macID + share["MACAddress"].ToString().Trim();
                    break;
                }
            }

            return macID;
        }
    }
}
