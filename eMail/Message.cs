using System;

namespace eMail;

public class Message : IBaseClass
{
    private int _id;
    private string _subject;
    private DateTime _sendDate;
    private int senderId;
    private int receiverId;
    private bool senderShow;
    private bool receiverShow;


    public Message(int id, string subject, DateTime sendDate, int senderId, int receiverId, bool senderShow, bool receiverShow)
    {
        _id = id;
        _subject = subject;
        _sendDate = sendDate;
        this.senderId = senderId;
        this.receiverId = receiverId;
        this.senderShow = senderShow;
        this.receiverShow = receiverShow;
    }

    public Message(string subject, int senderId, int receiverId)
    {
        _subject = subject;
        this.senderId = senderId;
        this.receiverId = receiverId;
        this.senderShow = true;
        this.receiverShow = true;
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
        get => senderId;
        set => senderId = value;
    }

    public int ReceiverId
    {
        get => receiverId;
        set => receiverId = value;
    }

    public bool SenderShow
    {
        get => senderShow;
        set => senderShow = value;
    }

    public bool ReceiverShow
    {
        get => receiverShow;
        set => receiverShow = value;
    }


    public int Id
    {
        get => _id;
        set => _id = value;
    }
    
}