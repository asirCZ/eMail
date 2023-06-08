using System;
using System.Windows.Forms;
using eMail.DAO;

namespace eMail.Window_Forms
{
    /// <summary>
    /// Represents a form for reading an email.
    /// </summary>
    public partial class ReadEmail : Form
    {
        private readonly MessageDao _messageDao = new();
        private readonly int _replySender;
        private readonly UserDao _userDao = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="ReadEmail"/> class.
        /// </summary>
        /// <param name="id">The ID of the email to load.</param>
        /// <param name="inbox">A boolean indicating whether the email is in the inbox or not.</param>
        /// <param name="replySender">The sender of the reply.</param>
        public ReadEmail(int id, bool inbox, int replySender)
        {
            _replySender = replySender;
            InitializeComponent();
            LoadEmail(id, inbox);
        }

        private void LoadEmail(int id, bool inbox)
        {
            var message = _messageDao.GetById(id);
            if (inbox)
                replyBtn.Visible = true;
            else
                replyBtn.Visible = false;
            LoadRecipientList(message);
            senderTxt.Text = _userDao.GetNameById(message.SenderId);
            subjectTxt.Text = message.Subject;
            messageTxt.Text = message.Message1;
            date.Text += message.SendDate + @".";
        }

        /// <summary>
        /// Event handler for the reply button click.
        /// </summary>
        private void replyBtn_Click(object sender, EventArgs e)
        {
            var we = new WriteEmail(_replySender, senderTxt.Text);
            we.Visible = true;
        }

        private void LoadRecipientList(Message m)
        {
            listOfRecipients.Items.Clear();
            foreach (var keyValuePair in m.Recipients) 
            {
                listOfRecipients.Items.Add(_userDao.GetNameById(keyValuePair.Key));
            }
        }
    }
}
