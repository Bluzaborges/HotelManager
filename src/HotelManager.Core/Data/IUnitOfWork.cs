namespace HotelManager.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangesAsync();
    }
}