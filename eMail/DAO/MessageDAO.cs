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
        var recipientNames = GetRecipientsByMessageId(id);
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
                    recipientNames);
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

        Console.WriteLine(messageId);
        foreach (KeyValuePair<int,bool> recipient in element.Recipients)
        {
            Console.WriteLine(recipient.Key);
            Console.WriteLine(recipient.Value);
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
            var dataTable = new DataTable();
            using (var reader = command.ExecuteReader())
            {
                dataTable.Load(reader);
            }
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
            var dataTable = new DataTable();
            using (var reader = command.ExecuteReader())
            {
                dataTable.Load(reader);
            }
            return dataTable;
        }
    }

    public void RecipientDeleted(int recipientId, int messageId)
    {
        var conn = DatabaseSingleton.GetInstance();
        using (var command = new SqlCommand("DeleteRecipient", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_msg", messageId);
            command.Parameters.AddWithValue("@id_recipient", recipientId);
            command.ExecuteNonQuery();
        }
    }

    public void SenderDeleted(int messageId)
    {
        {
            var conn = DatabaseSingleton.GetInstance();
            using (var command = new SqlCommand("DeleteSender", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id_msg", messageId);
                command.ExecuteNonQuery();
            }
        }
    }

    private List<int> GetRecipientsByMessageId(int id)
    {
        List<int> list = new List<int>();
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
                    list.Add(recipientId);
                }
            }
        }

        return list;
    }

}