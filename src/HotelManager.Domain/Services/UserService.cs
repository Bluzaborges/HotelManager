using HotelManager.Security.Password;
using HotelManager.Domain.Services.Abstractions;

namespace HotelManager.Domain.Services
{
    public class UserService : IUserService
    {
        public string EncryptPassword(string? password)
        {
            return PasswordEncrypt.AESEncrypt(password);
        }

        public string DecryptPassword(string? encryptedPassword)
        {
            return PasswordEncrypt.AESDecrypt(encryptedPassword);
        }
    }
}