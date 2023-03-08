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
    private bool inbox = true;

    public EmailWindow()
    {
        InitializeComponent();
        registerPanel.Visible = false;
        appPanel.Visible = false;
        DatabaseSingleton.GetInstance();
    }

    private void loginBtn_Click(object sender, EventArgs e)
    {
        _user = null;
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
            return;
        }

        _user.Id = _uDao.GetIdFromUsername(_user.Username);
        LoadReceivedEmails();
        loginPanel.Visible = false;
        appPanel.Visible = true;
        usernameTxt.Text = "";
        passwordTxt.Text = "";
        errorLabelLog.Text = "";
    }

    private void LoadReceivedEmails()
    {
        emailList.DataSource = _mDao.GetEmailsForId(_user.Id);
        if (emailList.Columns.Contains("MessageID"))
        {
            emailList.Columns["MessageID"]!.Visible = false;
        }
    }

    private void LoadSentEmails()
    {
        emailList.DataSource = _mDao.GetEmailsFromId(_user.Id);
        if (emailList.Columns.Contains("MessageID"))
        {
            emailList.Columns["MessageID"]!.Visible = false;
        }
    }

    private void registerBtn_Click(object sender, EventArgs e)
    {
        _user = null;
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
        if (!_uDao.UserExists(_user.Username))
        {
            errorLabelReg.Text = @"Error! Unable to register!";
            return;
        }

        registerPanel.Visible = false;
        appPanel.Visible = false;
        loginPanel.Visible = true;
        _user = null;
        regUserTxt.Text = "";
        regPasswordTxt.Text = "";
        regRepeatTxt.Text = "";
        errorLabelReg.Text = "";
        errorLabelLog.ForeColor = Color.Green;
        errorLabelLog.Text = @"Your new account has been successfully registered!";
    }

    private void emailList_DeletingRow(object sender, DataGridViewRowCancelEventArgs e)
    {
        if (inbox)
        {
            _mDao.ReceiverDeleted(Int32.Parse(emailList.Rows[e.Row.Index].Cells["MessageID"].Value.ToString()));
        }
        else
        {
            _mDao.SenderDeleted(Int32.Parse(emailList.Rows[e.Row.Index].Cells["MessageID"].Value.ToString()));
        }
    }
    private void emailList_DoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        ReadEmail re = new ReadEmail(Int32.Parse(emailList.Rows[e.RowIndex].Cells["MessageID"].Value.ToString()), inbox);
        re.Visible = true;
    }

    private void newMailBtn_Click(object sender, EventArgs e)
    {
        WriteEmail we = new WriteEmail(_user.Id);
        we.Visible = true;
    }

    private void toggleEmailsBtn_Click(object sender, EventArgs e)
    {
        if(inbox){
            toggleEmailsBtn.Text = @"Inbox";
            headerLabel.Text = @"Sent:";
            LoadSentEmails();
            inbox = false;
        }
        else
        {
            toggleEmailsBtn.Text = @"Sent";
            headerLabel.Text = @"Inbox:";
            LoadReceivedEmails();
            inbox = true;
        }
        
    }

    private void registerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        loginPanel.Visible = false;
        appPanel.Visible = false;
        registerPanel.Visible = true;
        usernameTxt.Text = "";
        passwordTxt.Text = "";
        errorLabelLog.Text = "";
        
    }

    private void logoutBtn_Click(object sender, EventArgs e)
    {
        _user = null;
        appPanel.Visible = false;
        registerPanel.Visible = false;
        loginPanel.Visible = true;
    }
}