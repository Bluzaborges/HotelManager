using HotelManager.Core.Data;
using HotelManager.Domain.Entities;

namespace HotelManager.Domain.Abstractions.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserByIdAsync(Guid id);

        Task<User?> GetUserByCpfAsync(Guid id, string? cpf);

        Task<User?> GetUserByEmailAsync(Guid id, string? email);

        Task<User?> GetUserByEmailPasswordAsync(string? email, string? password);

        void AddUser(User user);

        void UpdateUser(User user);
    }
}