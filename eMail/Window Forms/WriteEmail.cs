using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace eMail;

public partial class WriteEmail : Form
{
    private readonly MessageDao _mDao = new();
    private readonly UserDao _uDao = new();
    private readonly int _senderId;
    private LinkedList<string> _recipients = new();

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
        var recipientsIds = new int[_recipients.Count];
        foreach (var recipient in _recipients.Where(recipient => !_uDao.UserExists(recipient)))
        {
            MessageBox.Show(@"Account """ + recipient + @""" doesn't exist.");
            return;
        }

        if (messageTxt.Text.Length == 0)
        {
            MessageBox.Show(@"Cannot send an empty e-mail.");
            return;
        }

        var m = new Message(subjectTxt.Text, messageTxt.Text, _senderId, recipientsIds);
        _mDao.Save(m);
        Close();
        MessageBox.Show(@"E-mail has been successfully sent.");
    }

    private void addRecipient_Click(object sender, EventArgs e)
    {
        if (!_uDao.UserExists(recipientTxt.Text))
        {
            MessageBox.Show(@"Cannot find such account in the database.");
            return;
        }

        _recipients.AddLast(recipientTxt.Text);
        ReloadRecipientList();

    }

    private void ReloadRecipientList()
    {
        listOfRecipients.Items.Clear();
        foreach (var recipient in _recipients)
        {
            listOfRecipients.Items.Add(recipient);
        }
    }
}