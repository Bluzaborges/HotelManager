namespace HotelManager.Domain.Services.Abstractions
{
    public interface IUserService
    {
        string EncryptPassword(string? password);

        string DecryptPassword(string? encryptedPassword);
    }
}