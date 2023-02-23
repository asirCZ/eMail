using System;
using System.Windows.Forms;

namespace eMail
{
    public partial class EmailWindow : Form
    {
        private User _user;
        private UserDAO _uDao = new();
        public EmailWindow()
        {
            InitializeComponent();
            DatabaseSingleton.GetInstance();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            errorLabelLog.Text = "";
            _user = new User(usernameTxt.Text, passwordTxt.Text);
            if (_uDao.UserExists(_user))
            {
                errorLabelLog.Text = @"Error! There appears to be no account associated with the provided username. Please verify that the username was entered correctly and that an account exists for it in our system.";
                return;
            }

            if (!_uDao.PasswordMatches(_user))
            {
                errorLabelLog.Text = @"Error! The entered password does not match the password on file. Please double-check that the correct password has been entered.";
            }
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            errorLabelReg.Text = "";
            if (regPasswordTxt.Text != regRepeatTxt.Text)
            {
                errorLabelReg.Text = @"Error! The passwords you entered do not match. Please ensure that both passwords match and try again.";
                return;
            }

            if (regPasswordTxt.Text.Length < 7)
            {
                errorLabelReg.Text = @"Error! The password you entered is too short. Passwords must be at least 8 characters long. Please enter a password that is at least 8 characters long and try again.";
            }
            _user = new User(regUserTxt.Text, regPasswordTxt.Text);
            if (_uDao.UserExists(_user))
            {
                errorLabelReg.Text = @"Error! The username you entered is already in use. Please choose a different username and try again.";
            }
        }

        private void emailList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
