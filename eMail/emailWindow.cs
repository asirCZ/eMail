using System;
using System.Windows.Forms;

namespace eMail
{
    public partial class EmailWindow : Form
    {
        private User _user;
        public EmailWindow()
        {
            InitializeComponent();
            DatabaseSingleton.GetInstance();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            _user = new User(usernameTxt.Text, passwordTxt.Text);
            if (!_user.UserExists())
            {
                errorLabelLog.Text = @"Error! There appears to be no account associated with the provided username. Please verify that the username was entered correctly and that an account exists for it in our system.";
                return;
            }

            if (!_user.PasswordMatches())
            {
                errorLabelLog.Text = @"Error! The entered password does not match the password on file. Please double-check that the correct password has been entered.";
            }
        }
    }
}
