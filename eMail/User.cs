using System;
using System.Data.SqlClient;

namespace eMail
{
    internal class User
    {
        private Guid _id;
        private string _username;
        private string _password;

        public Guid Id => _id;

        public User(string username, string password)
        {
            this._username = username;
            this._password = password;
        }

        public bool UserExists()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();
            string selUsername;

            using (SqlCommand command = new SqlCommand("SELECT Username FROM Accounts WHERE Username = @name", conn))
            {
                command.Parameters.Add(new SqlParameter("@name", _username));
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

            return _username == selUsername;
        }

        public bool PasswordMatches()
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();
            using (SqlCommand command =
                   new SqlCommand("SELECT Guid FROM Accounts WHERE Username = @name AND Password = @pass", conn))
            {
                command.Parameters.Add(new SqlParameter("@name", _username));
                command.Parameters.Add(new SqlParameter("@pass", _password));
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        _id = Guid.ParseExact(reader[0].ToString(), "N");
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