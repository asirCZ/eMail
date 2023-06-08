using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace eMail.DAO;

/// <summary>
///     Data Access Object for managing user data in the database.
/// </summary>
public class UserDao : IDao<User>
{
    /// <summary>
    ///     Retrieves a user by their ID.
    /// </summary>
    /// <param name="id">The ID of the user.</param>
    /// <returns>The user with the specified ID, or null if not found.</returns>
    public User GetById(int id)
    {
        User u;
        var conn = DatabaseSingleton.GetInstance();
        using (var command = new SqlCommand("SELECT id, Username, Password FROM Accounts A WHERE A.id = @id", conn))
        {
            command.Parameters.Add(new SqlParameter("@id", id));
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    u = new User(int.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), true);
                    return u;
                }

                return null;
            }
        }
    }

    /// <summary>
    ///     Gets all users.
    /// </summary>
    /// <returns>A collection of all users.</returns>
    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Saves a user to the database.
    /// </summary>
    /// <param name="element">The user to be saved.</param>
    public void Save(User element)
    {
        var conn = DatabaseSingleton.GetInstance();

        using (var command = new SqlCommand("INSERT INTO Accounts(Username, Password) VALUES (@name, @pass)", conn))
        {
            command.Parameters.Add(new SqlParameter("@name", element.Username));
            command.Parameters.Add(new SqlParameter("@pass", element.Password));
            command.ExecuteNonQuery();
            command.CommandText = "SELECT @Identity";
        }
    }

    /// <summary>
    ///     Deletes a user from the database.
    /// </summary>
    /// <param name="element">The user to be deleted.</param>
    public void Delete(User element)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Checks if a user with the specified username exists in the database.
    /// </summary>
    /// <param name="username">The username to check.</param>
    /// <returns>The ID of the user if found, or 0 if not found.</returns>
    public int GetUserId(string username)
    {
        var conn = DatabaseSingleton.GetInstance();
        var id = 0;

        using (var command = new SqlCommand("GetIdByName", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", username);

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                    id = Convert.ToInt32(reader["id"]);
            }
        }

        return id;
    }

    /// <summary>
    ///     Verifies if the password of a user matches the stored password in the database.
    /// </summary>
    /// <param name="u">The user to verify.</param>
    /// <returns>True if the password matches, false otherwise.</returns>
    public bool PasswordMatches(User u)
    {
        string receivedPassword;
        var conn = DatabaseSingleton.GetInstance();
        using (var command = new SqlCommand("SELECT Password FROM Accounts WHERE Username = @name", conn))
        {
            command.Parameters.Add(new SqlParameter("@name", u.Username));
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                    receivedPassword = reader[0].ToString();
                else
                    return false;
            }
        }

        return PasswordEncryption.VerifyPassword(u.Password, receivedPassword);
    }

    /// <summary>
    ///     Gets the list of recently logged users for a specific user ID.
    /// </summary>
    /// <param name="id">The ID of the user.</param>
    /// <returns>A DataTable containing the list of recently logged users.</returns>
    public DataTable GetRecentUsers(int id)
    {
        var conn = DatabaseSingleton.GetInstance();

        using (var command = new SqlCommand("RecentlyLoggedUsers", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            var dataTable = new DataTable();
            using (var reader = command.ExecuteReader())
            {
                dataTable.Load(reader);
            }

            return dataTable;
        }
    }

    /// <summary>
    ///     Gets the username of a user by their ID.
    /// </summary>
    /// <param name="id">The ID of the user.</param>
    /// <returns>The username of the user, or null if not found.</returns>
    public string GetNameById(int id)
    {
        var conn = DatabaseSingleton.GetInstance();
        using (var command = new SqlCommand("GetNameById", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                return !reader.Read() ? null : reader["username"].ToString();
            }
        }
    }

    /// <summary>
    ///     Logs the authentication of a user.
    /// </summary>
    /// <param name="id">The ID of the user.</param>
    public void LogAuthentication(int id)
    {
        var conn = DatabaseSingleton.GetInstance();
        using (var command = new SqlCommand("LogAuthentication", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }
    }
}