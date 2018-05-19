using System;
using System.Security.Cryptography;
using System.Text;

namespace KillerAppASP.Models
{
    public static class PasswordEncryptor
    {
        public static string EncryptPassword(string password)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.Unicode.GetBytes(password));
            string encryptedPassword = BitConverter.ToString(bytes).Replace("-", string.Empty);
            return encryptedPassword;
        }
    }
}
