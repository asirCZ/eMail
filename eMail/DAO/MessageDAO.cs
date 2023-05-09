using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace eMail;

public class MessageDao : IDao<Message>
{
    public Message GetById(int id)
    {
        Message m;
        var conn = DatabaseSingleton.GetInstance();
        using (var command = new SqlCommand("GetMessageById", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                if (!reader.Read()) return null;
                m = new Message(id, reader[0].ToString(), reader[1].ToString(),
                    DateTime.Parse(reader[2].ToString()), int.Parse(reader[3].ToString()),
                    GetRecipientsByMessageId(id));
                return m;

            }
        }
    }

    public IEnumerable<Message> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Save(Message element)
    {
        int messageId;
        var conn = DatabaseSingleton.GetInstance();

        using (var command = new SqlCommand("SendEmail", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@subject", element.Subject);
            command.Parameters.AddWithValue("@message", element.Message1);
            command.Parameters.AddWithValue("@sender_id", element.SenderId);
            command.Parameters.AddWithValue("@sender_show", element.SenderShow);
            messageId = (int)command.ExecuteScalar();
        }
        foreach (KeyValuePair<int,bool> recipient in element.Recipients)
        {
            using (var command = new SqlCommand("AssignRecipient", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@recipient_id", recipient.Key);
                command.Parameters.AddWithValue("@message_id", messageId);
                command.Parameters.AddWithValue("@recipient_show", recipient.Value);
                command.ExecuteNonQuery();
            }
        }

    }

    public void Delete(Message element)
    {
        throw new NotImplementedException();
    }

    public DataTable GetEmailsForId(int id)
    {
        var conn = DatabaseSingleton.GetInstance();


        using (var command = new SqlCommand("GetMessagesByRecipientId", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            var reader = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);

            return dataTable;
        }
    }

    public object GetEmailsFromId(int id)
    {
        var conn = DatabaseSingleton.GetInstance();


        using (var command = new SqlCommand("GetMessagesBySenderId", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            var reader = command.ExecuteReader();
            var dataTable = new DataTable();
            dataTable.Load(reader);

            return dataTable;
        }
    }

    public void ReceiverDeleted(int id)
    {
        var conn = DatabaseSingleton.GetInstance();


        using (var command =
               new SqlCommand("UPDATE Messages SET receiverShow = receiverShow & ~1 WHERE id = @id", conn))
        {
            command.Parameters.Add(new SqlParameter("@id", id));
            command.ExecuteNonQuery();
        }
    }

    public void SenderDeleted(int id)
    {
        {
            var conn = DatabaseSingleton.GetInstance();


            using (var command =
                   new SqlCommand("UPDATE Messages SET senderShow = senderShow & ~1 WHERE id = @id", conn))
            {
                command.Parameters.Add(new SqlParameter("@id", id));
                command.ExecuteNonQuery();
            }
        }
    }

    public IEnumerable<int> GetRecipientsByMessageId(int id)
    {
        var conn = DatabaseSingleton.GetInstance();
        using (var command = new SqlCommand("GetRecipientsByMessageId", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int recipientId = Convert.ToInt32(reader["recipient_id"]);

                    yield return recipientId;
                }
            }
        }
    }
}