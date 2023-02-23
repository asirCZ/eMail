using System;
using System.Security.Cryptography;
using System.Text;

namespace eMail;

public class PasswordEncryption
{
    public static string EncryptPassword(string password, byte[] salt = null)
    {
        if (salt == null)
        {
            // Generate a random salt value
            salt = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
        }

        // Create a new instance of the SHA256 hashing algorithm
        SHA256 sha256 = SHA256.Create();

        // Convert the password and salt to byte arrays
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltedPasswordBytes = new byte[passwordBytes.Length + salt.Length];
        Buffer.BlockCopy(passwordBytes, 0, saltedPasswordBytes, 0, passwordBytes.Length);
        Buffer.BlockCopy(salt, 0, saltedPasswordBytes, passwordBytes.Length, salt.Length);

        // Compute the hash value for the salted password byte array
        byte[] hashBytes = sha256.ComputeHash(saltedPasswordBytes);

        // Convert the salt and hash value to base64-encoded strings
        string saltString = Convert.ToBase64String(salt);
        string hashString = Convert.ToBase64String(hashBytes);

        // Concatenate the salt and hash strings with a separator character
        string encryptedPassword = saltString + ":" + hashString;

        // Return the encrypted password string
        return encryptedPassword;
    }
    
    public static bool VerifyPassword(string inputPassword, string storedPasswordHash)
    {
        // Extract the salt value from the stored password hash
        byte[] salt = Convert.FromBase64String(storedPasswordHash.Split(':')[0]);

        // Compute the hash of the input password using the same salt value
        byte[] inputHash = new Rfc2898DeriveBytes(inputPassword, salt, 10000).GetBytes(32);

        // Convert the computed hash to a Base64-encoded string
        string computedPasswordHash = Convert.ToBase64String(inputHash);

        // Compare the computed hash with the stored hash
        return computedPasswordHash == storedPasswordHash.Split(':')[1];
    }
}