using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace eMail;

public class UserDAO : IDao<User>
{
    public User GetById(int id)
    {
        throw new System.NotImplementedException();
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

    public bool UserExists(User u)
    {
        SqlConnection conn = DatabaseSingleton.GetInstance();
        string selUsername;

        using (SqlCommand command = new SqlCommand("SELECT Username FROM Accounts WHERE Username = @name", conn))
        {
            command.Parameters.Add(new SqlParameter("@name", u.Username));
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    selUsername = reader.GetString(0);
                }
                else
                {
                    return false;
                }
            }
        }

        return u.Username == selUsername;
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
}