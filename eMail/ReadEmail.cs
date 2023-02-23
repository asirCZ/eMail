using System.Windows.Forms;

namespace eMail;

public partial class ReadEmail : Form
{
    private MessageDao _messageDao = new();
    private UserDao _userDao = new();
    public ReadEmail(int id)
    {
        InitializeComponent();
        LoadEmail(id);
    }

    private void LoadEmail(int id)
    {
        Message message = _messageDao.GetById(id);
        senderTxt.Text = _userDao.GetById(message.SenderId).Username;
        subjectTxt.Text = message.Subject;
        messageTxt.Text = message.Message1;
        date.Text += message.SendDate + @".";
    }
}