using System;
using System.Configuration;
using System.Data.SqlClient;

namespace eMail
{
    public class DatabaseSingleton
    {
        private static SqlConnection conn = null;
        private DatabaseSingleton()
        {

        }
        public static SqlConnection GetInstance()
        {
            if (conn == null)
            {
                SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
                consStringBuilder.UserID = ReadSetting("Name");
                consStringBuilder.Password = ReadSetting("Password");
                consStringBuilder.InitialCatalog = ReadSetting("Database");
                consStringBuilder.DataSource = ReadSetting("DataSource");
                consStringBuilder.ConnectTimeout = 1;
                conn = new SqlConnection(consStringBuilder.ConnectionString);
                Console.WriteLine(consStringBuilder.ConnectionString);
                try
                {
                    conn.Open();
                }
                catch (SqlException)
                {
                    consStringBuilder = new SqlConnectionStringBuilder();
                    consStringBuilder.InitialCatalog = ReadSetting("Database");
                    consStringBuilder.DataSource = ReadSetting("DataSourceWin");
                    consStringBuilder.IntegratedSecurity = true;
                    consStringBuilder.ConnectTimeout = 1;
                    conn = new SqlConnection(consStringBuilder.ConnectionString);
                    conn.Open();
                }

            }

            return conn;
        }

        public static void CloseConnection()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
            catch { }
            finally
            {
                conn = null;
            }
        }

        private static string ReadSetting(string key)
        {
            //nutno doinstalovat, VS nabídne doinstalaci samo
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key] ?? "Not Found";
            return result;
        }
    }
}
