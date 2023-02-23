using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace eMail;

public class UserDao : IDao<User>
{
    public User GetById(int id)
    {
        User u;
        SqlConnection conn = DatabaseSingleton.GetInstance();
        using (SqlCommand command = new SqlCommand("SELECT id, Username, Password FROM Accounts A WHERE A.id = @id", conn))
        {
            command.Parameters.Add(new SqlParameter("@id", id));
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    u = new User(Int32.Parse(reader[0].ToString()), reader[1].ToString(), reader[2].ToString(), true);
                    return u;
                }

                return null;
            }
        }
    }

    public IEnumerable<User> GetAll()
    {
        throw new System.NotImplementedException();
    }

    public void Save(User element)
    {
        SqlConnection conn = DatabaseSingleton.GetInstance();

        using (SqlCommand command =
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
        throw new System.NotImplementedException();
    }

    public bool UserExists(string username)
    {
        SqlConnection conn = DatabaseSingleton.GetInstance();
        string selUsername;

        using (SqlCommand command = new SqlCommand("SELECT Username FROM Accounts WHERE Username = @name", conn))
        {
            command.Parameters.Add(new SqlParameter("@name", username));
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return true;
                }
                
                return false;
            }
        }
    }
    
    public bool PasswordMatches(User u)
    {
        string receivedPassword;
        SqlConnection conn = DatabaseSingleton.GetInstance();
        using (SqlCommand command =
               new SqlCommand("SELECT Password FROM Accounts WHERE Username = @name", conn))
        {
            
            command.Parameters.Add(new SqlParameter("@name", u.Username));
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    receivedPassword = reader[0].ToString();
                }
                else
                {
                    return false;
                }
            }
        }

        return PasswordEncryption.VerifyPassword(u.Password, receivedPassword);

    }

    public int GetIdFromUsername(string username)
    {
        SqlConnection conn = DatabaseSingleton.GetInstance();
            using (SqlCommand command =
                   new SqlCommand("SELECT id FROM Accounts WHERE Username = @name", conn))
            {
            
                command.Parameters.Add(new SqlParameter("@name", username));
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (int)reader[0];
                    }

                    return 0;
                }
            }
    }
}