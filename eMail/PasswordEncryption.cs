using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace eMail;

public class PasswordEncryption
{
    public static string EncryptPassword(string password)
    {
        // Generate a random salt value
        byte[] salt = new byte[16];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Hash the password with the salt using the Argon2id algorithm
        Argon2id argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
        argon2.Salt = salt;
        argon2.DegreeOfParallelism = 8; // Number of threads to use
        argon2.MemorySize = 8192; // Amount of memory to use in kibibytes
        argon2.Iterations = 4; // Number of iterations

        byte[] hashedPassword = argon2.GetBytes(32); // Hash length of 32 bytes

        // Return the hashed password with the salt appended to it
        return Convert.ToBase64String(salt) + "." + Convert.ToBase64String(hashedPassword);
    }
    
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Extract the salt value and hashed password from the stored hashed password
        string[] parts = hashedPassword.Split('.');
        byte[] salt = Convert.FromBase64String(parts[0]);
        byte[] hashedPasswordBytes = Convert.FromBase64String(parts[1]);

        // Hash the input password with the extracted salt using the Argon2id algorithm
        Argon2id argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
        argon2.Salt = salt;
        argon2.DegreeOfParallelism = 8; // Number of threads to use
        argon2.MemorySize = 8192; // Amount of memory to use in kibibytes
        argon2.Iterations = 4; // Number of iterations

        byte[] hashedInputPassword = argon2.GetBytes(32); // Hash length of 32 bytes

        // Compare the hashed input password with the stored hashed password
        return StructuralComparisons.StructuralEqualityComparer.Equals(hashedPasswordBytes, hashedInputPassword);
    }
}