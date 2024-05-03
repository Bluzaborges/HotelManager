using System.Text;
using System.Security.Cryptography;
using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Security.Password
{
    public static class PasswordEncrypt
    {
        private readonly static string AES_KEY = "4S@edjLQr6U#^6@E7&NQ%*3h";

        public static string AESEncrypt(string? password)
        {
            if (string.IsNullOrEmpty(password))
                throw new InternalException();

            byte[] bytes = Encoding.UTF8.GetBytes(password);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(AES_KEY);
                aes.IV = new byte[16];
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform encryptor = aes.CreateEncryptor())
                {
                    return Convert.ToBase64String(encryptor.TransformFinalBlock(bytes, 0, bytes.Length));
                }
            }
        }

        public static string AESDecrypt(string? encryptedPassword)
        {
            if (string.IsNullOrEmpty(encryptedPassword))
                throw new InternalException();

            byte[] encryptedBytes = Convert.FromBase64String(encryptedPassword);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(AES_KEY);
                aes.IV = new byte[16];
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform decryptor = aes.CreateDecryptor())
                {
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

                    return Encoding.UTF8.GetString(decryptedBytes);
                }
            }
        }
    }
}