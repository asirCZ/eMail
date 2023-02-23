using System;

namespace eMail;

public class Message : IBaseClass
{
    private int _id;
    private string _subject;
    private string _message;
    private DateTime _sendDate;
    private int _senderId;
    private int _receiverId;
    private bool _senderShow;
    private bool _receiverShow;


    public Message(int id, string subject, string message, DateTime sendDate, int senderId, int receiverId, bool senderShow, bool receiverShow)
    {
        _id = id;
        _subject = subject;
        Message1 = message;
        _sendDate = sendDate;
        _senderId = senderId;
        _receiverId = receiverId;
        _senderShow = senderShow;
        _receiverShow = receiverShow;
    }

    public Message(string subject, string message, int senderId, int receiverId)
    {
        _subject = subject;
        Message1 = message;
        _senderId = senderId;
        _receiverId = receiverId;
        _senderShow = true;
        _receiverShow = true;
    }

    public Message(int id, string subject, string message, DateTime sendDate, int senderId, int receiverId)
    {
        _id = id;
        _subject = subject;
        _message = message;
        _sendDate = sendDate;
        _senderId = senderId;
        _receiverId = receiverId;
    }

    public string Subject
    {
        get => _subject;
        set => _subject = value;
    }

    public DateTime SendDate
    {
        get => _sendDate;
        set => _sendDate = value;
    }

    public int SenderId
    {
        get => _senderId;
        set => _senderId = value;
    }

    public int ReceiverId
    {
        get => _receiverId;
        set => _receiverId = value;
    }

    public bool SenderShow
    {
        get => _senderShow;
        set => _senderShow = value;
    }

    public bool ReceiverShow
    {
        get => _receiverShow;
        set => _receiverShow = value;
    }


    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Message1
    {
        get => _message;
        set => _message = value;
    }
}