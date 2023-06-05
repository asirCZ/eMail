using System;
using System.Drawing;
using System.Windows.Forms;

namespace eMail;

public partial class EmailWindow : Form
{
    private readonly MessageDao _mDao = new();
    private readonly UserDao _uDao = new();
    private bool _inbox = true;
    private User _user;

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
        int id = _uDao.UserExists(_user.Username);
        if (id == 0)
        {
            errorLabelLog.Text =
                @"Error! There appears to be no account associated with the provided username. Please verify that the username was entered correctly and that an account exists for it in our system.";
            return;
        }
        if (_user.Password.Length == 0 || !_uDao.PasswordMatches(_user))
        {
            errorLabelLog.Text =
                @"Error! The entered password does not match the password on file. Please double-check that the correct password has been entered.";
            return;
        }

        _user.Id = id;
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
        if (emailList.Columns.Contains("MessageID")) emailList.Columns["MessageID"]!.Visible = false;
    }

    private void LoadSentEmails()
    {
        emailList.DataSource = _mDao.GetEmailsFromId(_user.Id);
        if (emailList.Columns.Contains("MessageID")) emailList.Columns["MessageID"]!.Visible = false;
    }

    private void registerBtn_Click(object sender, EventArgs e)
    {
        _user = null;
        errorLabelReg.Text = "";
        errorLabelReg.ForeColor = Color.Red;
        if (regUserTxt.Text.Length < 3)
        {
            errorLabelReg.Text =
                @"Error! Username must contain at least 3 characters.";
            return;
        }
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
        if (_uDao.UserExists(_user.Username) != 0 )
        {
            errorLabelReg.Text =
                @"Error! The username you entered is already in use. Please choose a different username and try again.";
            return;
        }

        _user.EncryptPassword();
        _uDao.Save(_user);
        if (_uDao.UserExists(_user.Username) == 0)
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
        if (_inbox)
            _mDao.RecipientDeleted(_user.Id,int.Parse(emailList.Rows[e.Row.Index].Cells["MessageID"].Value.ToString()));
        else
            _mDao.SenderDeleted(int.Parse(emailList.Rows[e.Row.Index].Cells["MessageID"].Value.ToString()));
    }

    private void emailList_DoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        try
        {
            var re = new ReadEmail(int.Parse(emailList.Rows[e.RowIndex].Cells["MessageID"].Value.ToString()),
                _inbox);
            re.Visible = true;
        }
        catch (ArgumentOutOfRangeException){}
    }

    private void newMailBtn_Click(object sender, EventArgs e)
    {
        var we = new WriteEmail(_user.Id);
        we.Visible = true;
    }

    private void toggleEmailsBtn_Click(object sender, EventArgs e)
    {
        if (_inbox)
        {
            toggleEmailsBtn.Text = @"Inbox";
            headerLabel.Text = @"Sent:";
            LoadSentEmails();
            _inbox = false;
        }
        else
        {
            toggleEmailsBtn.Text = @"Sent";
            headerLabel.Text = @"Inbox:";
            LoadReceivedEmails();
            _inbox = true;
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