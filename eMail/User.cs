using System;
using System.Data.SqlClient;

namespace eMail
{
    public class User : IBaseClass
    {
        private int _id;
        private string _username;
        private string _password;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public User(string username, string password)
        {
            this._username = username;
            this._password = password;
        }


    }
}