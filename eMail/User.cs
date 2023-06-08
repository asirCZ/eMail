namespace eMail;

/// <summary>
///     Represents a user with a username and password.
/// </summary>
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

    public string Username { get; }

    public string Password { get; private set; }

    public int Id { get; set; }

    /// <summary>
    ///     Encrypts the user's password if it is not already encrypted.
    /// </summary>
    public void EncryptPassword()
    {
        if (_encrypted) return;
        Password = PasswordEncryption.EncryptPassword(Password);
        _encrypted = true;
    }
}