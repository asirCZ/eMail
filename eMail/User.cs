using System;
using System.Data.SqlClient;

namespace eMail
{
    public class User : IBaseClass
    {
        private int _id;
        private string _username;
        private string _password;
        private bool _encrypted = false;

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
            Username = username;
            Password = password;
        }

        public void EncryptPassword()
        {
            _password = PasswordEncryption.EncryptPassword(_password);
            _encrypted = true;
        }


    }
}