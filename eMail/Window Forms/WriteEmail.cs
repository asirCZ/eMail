using System;
using System.Collections.Generic;
using System.Windows.Forms;
using eMail.DAO;

namespace eMail.Window_Forms
{
    /// <summary>
    /// Represents a form for writing an email.
    /// </summary>
    public partial class WriteEmail : Form
    {
        private readonly MessageDao _mDao = new();
        private readonly LinkedList<string> _recipients = new();
        private readonly List<int> _recipientsIds = new();
        private readonly int _senderId;
        private readonly UserDao _uDao = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="WriteEmail"/> class.
        /// </summary>
        /// <param name="sender">The ID of the email sender.</param>
        /// <param name="recipient">The recipient of the email (optional).</param>
        public WriteEmail(int sender, string recipient = null)
        {
            _senderId = sender;
            InitializeComponent();
            if (recipient == null) return;
            AddRecipient(recipient);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void sendBtn_Click(object sender, EventArgs e)
        {
            if (messageTxt.Text.Length == 0)
            {
                MessageBox.Show(@"Cannot send an empty e-mail.");
                return;
            }

            var m = new Message(subjectTxt.Text, messageTxt.Text, _senderId, GetRecipientsIds());
            _mDao.Save(m);
            Close();
            MessageBox.Show(@"E-mail has been successfully sent.");
        }

        private void addRecipient_Click(object sender, EventArgs e)
        {
            AddRecipient();
        }

        private void AddRecipient(string username = null)
        {
            var userId = _uDao.GetUserId(username ?? recipientTxt.Text);

            if (userId == 0)
            {
                MessageBox.Show(@"Cannot find such account in the database.");
                return;
            }

            _recipients.AddLast(username ?? recipientTxt.Text);
            _recipientsIds.Add(userId);
            ReloadRecipientList();
            recipientTxt.Text = "";
        }

        private void ReloadRecipientList()
        {
            listOfRecipients.Items.Clear();
            foreach (var recipient in _recipients)
            {
                listOfRecipients.Items.Add(recipient);
            }
        }

        private IEnumerable<int> GetRecipientsIds()
        {
            return _recipientsIds;
        }
    }
}
