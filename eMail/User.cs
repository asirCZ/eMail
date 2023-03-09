namespace eMail;

public class User : IBaseClass
{
    private bool _encrypted;

    public User(string username, string password)
    {
        Username = username;
        Password = password;
    }

    public User(int id, string username, string password, bool encrypted)
    {
        Id = id;
        Username = username;
        Password = password;
        _encrypted = encrypted;
    }

    public string Username { get; set; }

    public string Password { get; set; }

    public int Id { get; set; }

    public void EncryptPassword()
    {
        Password = PasswordEncryption.EncryptPassword(Password);
        _encrypted = true;
    }
}