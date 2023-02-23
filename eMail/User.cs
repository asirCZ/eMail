using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMail
{
    internal class User
    {
        private Guid id;
        private string username;
        private string password;

        public Guid Id => id;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public bool UserExists()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();
            string selUsername = null;

            using (SqlCommand command = new SqlCommand("SELECT Username FROM Accounts WHERE Username = @name", conn))
            {
                command.Parameters.Add(new SqlParameter("@name", username));
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

            return username == selUsername;
        }

        public bool PasswordMatches()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();
            using (SqlCommand command =
                   new SqlCommand("SELECT Guid FROM Accounts WHERE Username = @name AND Password = @pass", conn))
            {
                command.Parameters.Add(new SqlParameter("@name", username));
                command.Parameters.Add(new SqlParameter("@pass", password));
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        id = Guid.ParseExact(reader[0].ToString(), "N");
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
}