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
        throw new System.NotImplementedException();
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
        SqlConnection conn = DatabaseSingleton.GetInstance();
        using (SqlCommand command =
               new SqlCommand("SELECT id FROM Accounts WHERE Username = @name AND Password = @pass", conn))
        {
            command.Parameters.Add(new SqlParameter("@name", u.Username));
            command.Parameters.Add(new SqlParameter("@pass", u.Password));
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    u.Id = Convert.ToInt32(reader[0].ToString());
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}