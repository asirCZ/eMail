using System;

namespace eMail;

public class Message : IBaseClass
{
    public Message(int id, string subject, string message, DateTime sendDate, int senderId, int receiverId,
        bool senderShow, bool receiverShow)
    {
        Id = id;
        Subject = subject;
        Message1 = message;
        SendDate = sendDate;
        SenderId = senderId;
        ReceiverId = receiverId;
        SenderShow = senderShow;
        ReceiverShow = receiverShow;
    }

    public Message(string subject, string message, int senderId, int receiverId)
    {
        Subject = subject;
        Message1 = message;
        SenderId = senderId;
        ReceiverId = receiverId;
        SenderShow = true;
        ReceiverShow = true;
    }

    public Message(int id, string subject, string message, DateTime sendDate, int senderId, int receiverId)
    {
        Id = id;
        Subject = subject;
        Message1 = message;
        SendDate = sendDate;
        SenderId = senderId;
        ReceiverId = receiverId;
    }

    public string Subject { get; set; }

    public DateTime SendDate { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public bool SenderShow { get; set; }

    public bool ReceiverShow { get; set; }

    public string Message1 { get; set; }


    public int Id { get; set; }
}