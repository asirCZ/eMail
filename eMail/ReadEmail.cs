using System.Windows.Forms;

namespace eMail;

public partial class ReadEmail : Form
{
    private MessageDao _messageDao = new();
    private UserDao _userDao = new();
    public ReadEmail(int id, bool inbox)
    {
        InitializeComponent();
        LoadEmail(id, inbox);
    }

    private void LoadEmail(int id, bool inbox)
    {
        Message message = _messageDao.GetById(id);
        if (inbox)
        {
            senderLabel.Text = @"Sender:";
            senderTxt.Text = _userDao.GetById(message.SenderId).Username;
        }
        else
        {
            senderLabel.Text = @"Recipient:";
            senderTxt.Text = _userDao.GetById(message.ReceiverId).Username;
        }

        subjectTxt.Text = message.Subject;
        messageTxt.Text = message.Message1;
        date.Text += message.SendDate + @".";
    }
}