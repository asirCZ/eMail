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
        SqlConnection conn = DatabaseSingleton.GetInstance();
        using (SqlCommand command = new SqlCommand("SELECT subject, message, sendDate, senderId, receiverId FROM Messages M WHERE M.id = @id AND receiverShow = 1", conn))
        {
            command.Parameters.Add(new SqlParameter("@id", id));
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    m = new Message(id, reader[0].ToString(), reader[1].ToString(), DateTime.Parse(reader[2].ToString()), Int32.Parse(reader[3].ToString()), Int32.Parse(reader[4].ToString()));
                    return m;
                }

                return null;
            }
        }
    }

    public IEnumerable<Message> GetAll()
    {
        throw new System.NotImplementedException();
    }

    public void Save(Message element)
    {
        SqlConnection conn = DatabaseSingleton.GetInstance();

        using (SqlCommand command = new SqlCommand("SendEmail", conn))
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
        SqlConnection conn = DatabaseSingleton.GetInstance();
        

        using (SqlCommand command = new SqlCommand("GetMessagesByReceiverId", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);

            return dataTable;
        }
    }
    public void ReceiverDeleted(int id)
    {
        SqlConnection conn = DatabaseSingleton.GetInstance();
        

        using (SqlCommand command =
               new SqlCommand("UPDATE Messages SET receiverShow = receiverShow & ~1 WHERE id = @id", conn))
        {
            command.Parameters.Add(new SqlParameter("@id", id));
            command.ExecuteNonQuery();
        }
    }
}