using System;
using System.Configuration;
using System.Data.SqlClient;

namespace eMail;

public static class DatabaseSingleton
{
    private static SqlConnection _conn;

    public static SqlConnection GetInstance()
    {
        if (_conn == null)
        {
            var consStringBuilder = new SqlConnectionStringBuilder();
            consStringBuilder.UserID = ReadSetting("Name");
            consStringBuilder.Password = ReadSetting("Password");
            consStringBuilder.InitialCatalog = ReadSetting("Database");
            consStringBuilder.DataSource = ReadSetting("DataSource");
            consStringBuilder.ConnectTimeout = 1;
            _conn = new SqlConnection(consStringBuilder.ConnectionString);
            Console.WriteLine(consStringBuilder.ConnectionString);
            try
            {
                _conn.Open();
            }
            catch (SqlException sqlE)
            {
                Console.WriteLine(sqlE);
                consStringBuilder = new SqlConnectionStringBuilder();
                consStringBuilder.InitialCatalog = ReadSetting("Database");
                consStringBuilder.DataSource = ReadSetting("DataSourceWin");
                consStringBuilder.IntegratedSecurity = true;
                consStringBuilder.ConnectTimeout = 1;
                _conn = new SqlConnection(consStringBuilder.ConnectionString);
                _conn.Open();
            }
        }

        return _conn;
    }

    public static void CloseConnection()
    {
        try
        {
            if (_conn != null)
            {
                _conn.Close();
                _conn.Dispose();
            }
        }
        catch
        {
            // ignored
        }
        finally
        {
            _conn = null;
        }
    }

    private static string ReadSetting(string key)
    {
        var appSettings = ConfigurationManager.AppSettings;
        var result = appSettings[key] ?? "Not Found";
        return result;
    }
}