using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMail
{
    public partial class emailWindow : Form
    {
        private User user;
        public emailWindow()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            user = new User(usernameTxt.Text, passwordTxt.Text);
            if (!user.UserExists())
            {
                errorLabelLog.Text = @"Error! There appears to be no account associated with the provided username. Please verify that the username was entered correctly and that an account exists for it in our system.";
                return;
            }

            if (!user.PasswordMatches())
            {
                errorLabelLog.Text = @"Error! The entered password does not match the password on file. Please double-check that the correct password has been entered.";
            }
        }
    }
}
