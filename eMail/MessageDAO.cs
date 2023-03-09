using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace eMail;

public class MessageDao : IDao<Message>
{
    public Message GetById(int id)
    {
        Message m;
        var conn = DatabaseSingleton.GetInstance();
        using (var command =
               new SqlCommand(
                   "SELECT subject, message, sendDate, senderId, receiverId FROM Messages M WHERE M.id = @id AND receiverShow = 1",
                   conn))
        {
            command.Parameters.Add(new SqlParameter("@id", id));
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    m = new Message(id, reader[0].ToString(), reader[1].ToString(),
                        DateTime.Parse(reader[2].ToString()), int.Parse(reader[3].ToString()),
                        int.Parse(reader[4].ToString()));
                    return m;
                }

                return null;
            }
        }
    }

    public IEnumerable<Message> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Save(Message element)
    {
        var conn = DatabaseSingleton.GetInstance();

        using (var command = new SqlCommand("SendEmail", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@subject", element.Subject);
            command.Parameters.AddWithValue("@message", element.Message1);
            command.Parameters.AddWithValue("@senderId", element.SenderId.ToString());
            command.Parameters.AddWithValue("@recipientId", element.ReceiverId.ToString());
            command.ExecuteNonQuery();
        }
    }

    public void Delete(Message element)
    {
        throw new NotImplementedException();
    }

    public DataTable GetEmailsForId(int id)
    {
        var conn = DatabaseSingleton.GetInstance();


        using (var command = new SqlCommand("GetMessagesByReceiverId", conn))
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
}