using System;
using System.Security.Cryptography;
using System.Text;

namespace hotelmngsystem.Helpers
{
    /// <summary>
    /// Basic SHA-256 password hashing. Good enough for a local front-desk
    /// training/demo app; for production use a salted algorithm (PBKDF2/BCrypt).
    /// </summary>
    internal static class PasswordHelper
    {
        public static string Hash(string plainText)
        {
            if (plainText == null) plainText = string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainText));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static bool Verify(string plainText, string hash)
        {
            return string.Equals(Hash(plainText), hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
