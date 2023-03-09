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