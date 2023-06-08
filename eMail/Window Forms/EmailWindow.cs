using System;
using System.Drawing;
using System.Windows.Forms;
using eMail.DAO;

namespace eMail.Window_Forms;

/// <summary>
///     Represents the main window form for the email client application.
/// </summary>
public partial class EmailWindow : Form
{
    private readonly MessageDao _mDao = new(); // Data access object for managing email messages
    private readonly UserDao _uDao = new(); // Data access object for managing user data
    private bool _inbox = true; // Flag to indicate whether the current view is the inbox or sent folder
    private User _user; // The currently logged-in user

    public EmailWindow()
    {
        InitializeComponent();
        registerPanel.Visible = false;
        appPanel.Visible = false;
        DatabaseSingleton.GetInstance(); // Initializes the database connection
    }

    /// <summary>
    ///     Event handler for the login button click.
    ///     Attempts to log in the user with the provided username and password.
    /// </summary>
    private void loginBtn_Click(object sender, EventArgs e)
    {
        _user = null;
        errorLabelLog.Text = "";
        errorLabelLog.ForeColor = Color.Red;
        _user = new User(usernameTxt.Text, passwordTxt.Text);

        // Check if the user exists in the database
        var id = _uDao.GetUserId(_user.Username);
        if (id == 0)
        {
            errorLabelLog.Text =
                @"Error! There appears to be no account associated with the provided username. Please verify that the username was entered correctly and that an account exists for it in our system.";
            return;
        }

        // Check if the entered password matches the password on file
        if (_user.Password.Length == 0 || !_uDao.PasswordMatches(_user))
        {
            errorLabelLog.Text =
                @"Error! The entered password does not match the password on file. Please double-check that the correct password has been entered.";
            return;
        }

        _user.Id = id;
        _inbox = false;
        _uDao.LogAuthentication(id);
        toggleEmailsBtn_Click(sender, e);
        LoadRecentUsers();
        loginPanel.Visible = false;
        appPanel.Visible = true;
        usernameTxt.Text = "";
        passwordTxt.Text = "";
        errorLabelLog.Text = "";
    }

    /// <summary>
    ///     Loads the received emails for the currently logged-in user.
    /// </summary>
    private void LoadReceivedEmails()
    {
        emailList.DataSource = _mDao.GetEmailsForId(_user.Id);
        if (emailList.Columns.Contains("MessageID"))
            emailList.Columns["MessageID"]!.Visible = false;
    }

    /// <summary>
    ///     Loads the sent emails by the currently logged-in user.
    /// </summary>
    private void LoadSentEmails()
    {
        emailList.DataSource = _mDao.GetEmailsFromId(_user.Id);
        if (emailList.Columns.Contains("MessageID"))
            emailList.Columns["MessageID"]!.Visible = false;
    }

    /// <summary>
    ///     Loads the recently logged-in users for the currently logged-in user.
    /// </summary>
    private void LoadRecentUsers()
    {
        recentLoginsList.DataSource = _uDao.GetRecentUsers(_user.Id);
    }

    /// <summary>
    ///     Event handler for the register button click.
    ///     Attempts to register a new user with the provided username and password.
    /// </summary>
    private void registerBtn_Click(object sender, EventArgs e)
    {
        _user = null;
        errorLabelReg.Text = "";
        errorLabelReg.ForeColor = Color.Red;

        // Validate username
        if (regUserTxt.Text.Length < 3)
        {
            errorLabelReg.Text = @"Error! Username must contain at least 3 characters.";
            return;
        }

        // Validate password
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

        // Check if the username already exists
        if (_uDao.GetUserId(_user.Username) != 0)
        {
            errorLabelReg.Text =
                @"Error! The username you entered is already in use. Please choose a different username and try again.";
            return;
        }

        _user.EncryptPassword();
        _uDao.Save(_user);

        // Check if the user was successfully registered
        if (_uDao.GetUserId(_user.Username) == 0)
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

    /// <summary>
    ///     Event handler for deleting a row (email) in the email list.
    /// </summary>
    private void emailList_DeletingRow(object sender, DataGridViewRowCancelEventArgs e)
    {
        if (_inbox)
            _mDao.RecipientDeleted(_user.Id,
                int.Parse(emailList.Rows[e.Row.Index].Cells["MessageID"].Value.ToString()));
        else
            _mDao.SenderDeleted(int.Parse(emailList.Rows[e.Row.Index].Cells["MessageID"].Value.ToString()));
    }

    /// <summary>
    ///     Event handler for double-clicking on an email in the email list.
    ///     Opens the selected email for reading.
    /// </summary>
    private void emailList_DoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        try
        {
            if (e.RowIndex < 0 || e.RowIndex >= emailList.Rows.Count) return;
            var re = new ReadEmail(int.Parse(emailList.Rows[e.RowIndex].Cells["MessageID"].Value.ToString()), _inbox,
                _user.Id);
            re.Visible = true;
        }
        catch (ArgumentOutOfRangeException)
        {
            // Ignored
        }
    }

    /// <summary>
    ///     Event handler for double-clicking on a recent login in the recent logins list.
    ///     Opens a new email composition window with the selected user as the recipient.
    /// </summary>
    private void recentLoginsList_DoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        try
        {
            if (e.RowIndex < 0 || e.RowIndex >= recentLoginsList.Rows.Count) return;
            var we = new WriteEmail(_user.Id, recentLoginsList.Rows[e.RowIndex].Cells["Username"].Value.ToString());
            we.Visible = true;
        }
        catch (ArgumentOutOfRangeException)
        {
            // Ignored
        }
    }

    /// <summary>
    ///     Event handler for the new mail button click.
    ///     Opens a new email composition window.
    /// </summary>
    private void newMailBtn_Click(object sender, EventArgs e)
    {
        var we = new WriteEmail(_user.Id);
        we.Visible = true;
    }

    /// <summary>
    ///     Event handler for the toggle emails button click.
    ///     Switches between displaying the inbox and the sent folder.
    /// </summary>
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

    /// <summary>
    ///     Event handler for the register link label click.
    ///     Switches to the registration panel.
    /// </summary>
    private void registerLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        loginPanel.Visible = false;
        appPanel.Visible = false;
        registerPanel.Visible = true;
        usernameTxt.Text = "";
        passwordTxt.Text = "";
        errorLabelLog.Text = "";
    }

    /// <summary>
    ///     Event handler for the logout button click.
    ///     Logs out the current user and switches to the login panel.
    /// </summary>
    private void logoutBtn_Click(object sender, EventArgs e)
    {
        _user = null;
        appPanel.Visible = false;
        registerPanel.Visible = false;
        loginPanel.Visible = true;
    }

    /// <summary>
    ///     Event handler for the login link label click.
    ///     Switches to the login panel.
    /// </summary>
    private void loginLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        registerPanel.Visible = false;
        appPanel.Visible = false;
        loginPanel.Visible = true;
        regPasswordTxt.Text = "";
        regUserTxt.Text = "";
        regRepeatTxt.Text = "";
    }
}