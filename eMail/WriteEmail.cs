using System;
using System.Windows.Forms;

namespace eMail;

public partial class WriteEmail : Form
{
    private int _senderId;
    private UserDao _uDao = new();
    private MessageDao _mDao = new();
    public WriteEmail(int sender)
    {
        _senderId = sender;
        InitializeComponent();
    }

    private void cancelBtn_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void sendBtn_Click(object sender, EventArgs e)
    {
        if (!_uDao.UserExists(recipientTxt.Text))
        {
            MessageBox.Show(@"Recipient account doesn't exist.");
            return;
        }

        Message m = new Message(subjectTxt.Text, messageTxt.Text, _senderId,  _uDao.GetIdFromUsername(recipientTxt.Text));
        _mDao.Save(m);
        Close();
        MessageBox.Show(@"E-mail has been successfully sent.");
    }
}