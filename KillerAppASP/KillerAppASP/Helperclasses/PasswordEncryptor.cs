using System;
using System.Security.Cryptography;
using System.Text;

namespace KillerAppASP.Helperclasses
{
	public static class PasswordEncryptor
	{
		public static string EncryptPassword(string password)
		{
			var sha256 = SHA256.Create();
			var bytes = sha256.ComputeHash(Encoding.Unicode.GetBytes(password));
			var encryptedPassword = BitConverter.ToString(bytes).Replace("-", string.Empty);
			return encryptedPassword;
		}
	}
}