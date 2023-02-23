using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMail;

public partial class EmailWindow : Form
{
    private User _user;
    private UserDao _uDao = new();
    private MessageDao _mDao = new();

    public EmailWindow()
    {
        InitializeComponent();
        DatabaseSingleton.GetInstance();
    }

    private void loginBtn_Click(object sender, EventArgs e)
    {
        errorLabelLog.Text = "";
        errorLabelLog.ForeColor = Color.Red;
        _user = new User(usernameTxt.Text, passwordTxt.Text);
        if (!_uDao.UserExists(_user.Username))
        {
            errorLabelLog.Text =
                @"Error! There appears to be no account associated with the provided username. Please verify that the username was entered correctly and that an account exists for it in our system.";
            return;
        }

        if (!_uDao.PasswordMatches(_user))
        {
            errorLabelLog.Text =
                @"Error! The entered password does not match the password on file. Please double-check that the correct password has been entered.";
        }

        _user.Id = _uDao.GetIdFromUsername(_user.Username);
        emailList.DataSource = _mDao.GetEmailsForId(_user.Id);
        if (emailList.Columns.Contains("MessageID"))
        {
            emailList.Columns["MessageID"]!.Visible = false;
        }

        errorLabelLog.ForeColor = Color.Green;
        errorLabelLog.Text = @"Congratulations! Yo have successfully logged into your account.";
    }

    private void registerBtn_Click(object sender, EventArgs e)
    {
        errorLabelReg.Text = "";
        errorLabelReg.ForeColor = Color.Red;
        if (regPasswordTxt.Text != regRepeatTxt.Text)
        {
            errorLabelReg.Text =
                @"Error! The passwords you entered do not match. Please ensure that both passwords match and try again.";
            return;
        }

        if (regPasswordTxt.Text.Length < 7)
        {
            errorLabelReg.Text =
                @"Error! The password you entered is too short. Passwords must be at least 8 characters long. Please enter a password that is at least 8 characters long and try again.";
            return;
        }

        _user = new User(regUserTxt.Text, regPasswordTxt.Text);
        if (_uDao.UserExists(_user.Username))
        {
            errorLabelReg.Text =
                @"Error! The username you entered is already in use. Please choose a different username and try again.";
            return;
        }

        _user.EncryptPassword();
        _uDao.Save(_user);
        if (_uDao.UserExists(_user.Username))
        {
            errorLabelReg.ForeColor = Color.Green;
            errorLabelReg.Text = @"Congratulations! Your account has been successfully registered.";
        }
        else
        {
            errorLabelReg.Text = @"Error! Unable to register!";
        }
    }

    private void emailList_DeletingRow(object sender, DataGridViewRowCancelEventArgs e)
    {
        // Do something with the column value

        _mDao.ReceiverDeleted(Int32.Parse(emailList.Rows[e.Row.Index].Cells["MessageID"].Value.ToString()));
    }
    private void emailList_DoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        ReadEmail re = new ReadEmail(Int32.Parse(emailList.Rows[e.RowIndex].Cells["MessageID"].Value.ToString()));
        re.Visible = true;
    }

    private void newMailBtn_Click(object sender, EventArgs e)
    {
        WriteEmail we = new WriteEmail(_user.Id);
        we.Visible = true;
    }
}