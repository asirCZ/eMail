using System;
using System.Configuration;
using System.Data.SqlClient;

namespace eMail;

/// <summary>
///     Represents a singleton class for managing database connections.
/// </summary>
public static class DatabaseSingleton
{
    private static SqlConnection _conn;

    /// <summary>
    ///     Gets the instance of the database connection.
    /// </summary>
    /// <returns>The SqlConnection instance.</returns>
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

    /// <summary>
    ///     Closes the database connection.
    /// </summary>
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
            // Ignored
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