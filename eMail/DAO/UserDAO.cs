using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace eMail;

public class UserDao : IDao<User>
{
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

    public IEnumerable<User> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Save(User element)
    {
        var conn = DatabaseSingleton.GetInstance();

        using (var command =
               new SqlCommand("INSERT INTO Accounts(Username, Password) VALUES (@name, @pass)", conn))
        {
            command.Parameters.Add(new SqlParameter("@name", element.Username));
            command.Parameters.Add(new SqlParameter("@pass", element.Password));
            command.ExecuteNonQuery();
            command.CommandText = "Select @Identity";
        }
    }

    public void Delete(User element)
    {
        throw new NotImplementedException();
    }

    public int UserExists(string username)
    {
        var conn = DatabaseSingleton.GetInstance();
        int id = 0;

        using (var command = new SqlCommand("GetIdByName", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", username);

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader["id"]);
                }
            }
        }

        return id;
    }

    public bool PasswordMatches(User u)
    {
        string receivedPassword;
        var conn = DatabaseSingleton.GetInstance();
        using (var command =
               new SqlCommand("SELECT Password FROM Accounts WHERE Username = @name", conn))
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

    public int GetIdFromUsername(string username)
    {
        var conn = DatabaseSingleton.GetInstance();
        using (var command =
               new SqlCommand("SELECT id FROM Accounts WHERE Username = @name", conn))
        {
            command.Parameters.Add(new SqlParameter("@name", username));
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read()) return (int)reader[0];

                return 0;
            }
        }
    }

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
}