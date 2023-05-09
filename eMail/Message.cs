using System;
using System.Collections.Generic;

namespace eMail;

public class Message : IBaseClass
{
    public string Subject { get;}

    public DateTime SendDate { get; }

    public int SenderId { get; }

    public bool SenderShow { get; }

    public string Message1 { get; }
    
    public readonly Dictionary<int, bool> Recipients = new();


    public int Id { get; }

    public Message(string subject, string message, int senderId, IEnumerable<int> recipientsIds)
    {
        Subject = subject;
        Message1 = message;
        SenderId = senderId;
        SenderShow = true;
        foreach (var id in recipientsIds)
        {
            Recipients.Add(id, true);
        }
    }

    public Message(int messageId, string subject, string message, DateTime sendDate, int senderId, IEnumerable<int> recipientsIds)
    {
        Id = messageId;
        Subject = subject;
        Message1 = message;
        SendDate = sendDate;
        SenderId = senderId;
        foreach (var id in recipientsIds)
        {
            Recipients.Add(id, true);
        }
    }
}