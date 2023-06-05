using System;
using System.Windows.Forms;

namespace eMail;

public partial class ReadEmail : Form
{
    private readonly MessageDao _messageDao = new();
    private readonly UserDao _userDao = new();

    public ReadEmail(int id, bool inbox)
    {
        InitializeComponent();
        LoadEmail(id, inbox);
    }

    private void LoadEmail(int id, bool inbox)
    {
        var message = _messageDao.GetById(id);
        if (inbox)
        {
            replyBtn.Visible = true;
        }
        else
        {
            replyBtn.Visible = false;
        }
        LoadRecipientList(message);
        senderTxt.Text = _userDao.GetNameById(message.SenderId);
        subjectTxt.Text = message.Subject;
        messageTxt.Text = message.Message1;
        date.Text += message.SendDate + @".";
    }

    private void replyBtn_Click(object sender, EventArgs e)
    {
        //TODO
    }
    private void LoadRecipientList(Message m)
    {
        listOfRecipients.Items.Clear();
        foreach (var recipient in m.Recipients)
        {
            listOfRecipients.Items.Add(_userDao.GetNameById(recipient.Key));
        }
    }
    
}