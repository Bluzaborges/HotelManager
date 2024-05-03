namespace HotelManager.Abstraction.Identity.Abstractions
{
    public interface IAuthUserData
    {
        Guid IdUser { get; }
        int UserRole { get; }
    }
}