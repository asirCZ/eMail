using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace eMail;

/// <summary>
///     Provides methods for encrypting and verifying passwords using the Argon2id algorithm.
/// </summary>
public static class PasswordEncryption
{
    /// <summary>
    ///     Encrypts a password using the Argon2id algorithm.
    /// </summary>
    /// <param name="password">The password to encrypt.</param>
    /// <returns>The encrypted password.</returns>
    public static string EncryptPassword(string password)
    {
        // Generate a random salt value
        var salt = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        // Hash the password with the salt using the Argon2id algorithm
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
        argon2.Salt = salt;
        argon2.DegreeOfParallelism = 8; // Number of threads to use
        argon2.MemorySize = 8192; // Amount of memory to use in kibibytes
        argon2.Iterations = 4; // Number of iterations

        var hashedPassword = argon2.GetBytes(32); // Hash length of 32 bytes

        // Return the hashed password with the salt appended to it
        return Convert.ToBase64String(salt) + "." + Convert.ToBase64String(hashedPassword);
    }

    /// <summary>
    ///     Verifies a password against a hashed password using the Argon2id algorithm.
    /// </summary>
    /// <param name="password">The password to verify.</param>
    /// <param name="hashedPassword">The hashed password to compare against.</param>
    /// <returns>True if the password is verified, false otherwise.</returns>
    public static bool VerifyPassword(string password, string hashedPassword)
    {
        // Extract the salt value and hashed password from the stored hashed password
        var parts = hashedPassword.Split('.');
        var salt = Convert.FromBase64String(parts[0]);
        var hashedPasswordBytes = Convert.FromBase64String(parts[1]);

        // Hash the input password with the extracted salt using the Argon2id algorithm
        var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
        argon2.Salt = salt;
        argon2.DegreeOfParallelism = 8; // Number of threads to use
        argon2.MemorySize = 8192; // Amount of memory to use in kibibytes
        argon2.Iterations = 4; // Number of iterations

        var hashedInputPassword = argon2.GetBytes(32); // Hash length of 32 bytes

        // Compare the hashed input password with the stored hashed password
        return StructuralComparisons.StructuralEqualityComparer.Equals(hashedPasswordBytes, hashedInputPassword);
    }
}