using System;
using System.Windows.Forms;

namespace eMail;

public partial class WriteEmail : Form
{
    private readonly MessageDao _mDao = new();
    private readonly int _senderId;
    private readonly UserDao _uDao = new();

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

        if (messageTxt.Text.Length == 0)
        {
            MessageBox.Show(@"Cannot send an empty e-mail.");
            return;
        }

        var m = new Message(subjectTxt.Text, messageTxt.Text, _senderId, _uDao.GetIdFromUsername(recipientTxt.Text));
        _mDao.Save(m);
        Close();
        MessageBox.Show(@"E-mail has been successfully sent.");
    }
}