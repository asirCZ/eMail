using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace eMail.DAO;

/// <summary>
///     Represents a Data Access Object (DAO) for managing Message objects.
/// </summary>
public class MessageDao : IDao<Message>
{
    /// <summary>
    ///     Retrieves a message by its ID.
    /// </summary>
    /// <param name="id">The ID of the message to retrieve.</param>
    /// <returns>The message with the specified ID, or null if not found.</returns>
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

    /// <summary>
    ///     Retrieves all messages.
    /// </summary>
    /// <returns>An enumerable collection of all messages.</returns>
    public IEnumerable<Message> GetAll()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Saves a message.
    /// </summary>
    /// <param name="element">The message to save.</param>
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
        foreach (var recipient in element.Recipients)
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

    /// <summary>
    ///     Deletes a message.
    /// </summary>
    /// <param name="element">The message to delete.</param>
    public void Delete(Message element)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///     Retrieves emails for a specific recipient ID.
    /// </summary>
    /// <param name="id">The ID of the recipient.</param>
    /// <returns>A DataTable containing the emails for the recipient ID.</returns>
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

    /// <summary>
    ///     Retrieves emails from a specific sender ID.
    /// </summary>
    /// <param name="id">The ID of the sender.</param>
    /// <returns>A DataTable containing the emails from the sender ID.</returns>
    public DataTable GetEmailsFromId(int id)
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

    /// <summary>
    ///     Deletes a recipient from a message.
    /// </summary>
    /// <param name="recipientId">The ID of the recipient to delete.</param>
    /// <param name="messageId">The ID of the message.</param>
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

    /// <summary>
    ///     Deletes a sender from a message.
    /// </summary>
    /// <param name="messageId">The ID of the message.</param>
    public void SenderDeleted(int messageId)
    {
        var conn = DatabaseSingleton.GetInstance();
        using (var command = new SqlCommand("DeleteSender", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id_msg", messageId);
            command.ExecuteNonQuery();
        }
    }

    /// <summary>
    ///     Retrieves the list of recipient IDs for a specific message ID.
    /// </summary>
    /// <param name="id">The ID of the message.</param>
    /// <returns>The list of recipient IDs.</returns>
    private List<int> GetRecipientsByMessageId(int id)
    {
        var list = new List<int>();
        var conn = DatabaseSingleton.GetInstance();
        using (var command = new SqlCommand("GetRecipientsByMessageId", conn))
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var recipientId = Convert.ToInt32(reader["recipient_id"]);
                    list.Add(recipientId);
                }
            }
        }

        return list;
    }
}