using Microsoft.EntityFrameworkCore;
using HotelManager.Core.Data;
using HotelManager.Data.Contexts;
using HotelManager.Domain.Abstractions.Repositories;
using HotelManager.Domain.Entities;

namespace HotelManager.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookingDbContext _bookingDbContext;

        public UserRepository(BookingDbContext bookingDbContext)
        {
            _bookingDbContext = bookingDbContext;
        }

        public IUnitOfWork UnitOfWork => _bookingDbContext;

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            return await _bookingDbContext.Users.FirstOrDefaultAsync(u => u.Id == id && u.Deleted == false);
        }

        public async Task<User?> GetUserByCpfAsync(Guid id, string? cpf)
        {
            return await _bookingDbContext.Users.FirstOrDefaultAsync(u => u.Cpf == cpf && u.Id != id && u.Deleted == false);
        }

        public async Task<User?> GetUserByEmailAsync(Guid id, string? email)
        {
            return await _bookingDbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Id != id && u.Deleted == false);
        }

        public async Task<User?> GetUserByEmailPasswordAsync(string? email, string? password)
        {
            return await _bookingDbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password && u.Deleted == false);
        }

        public void AddUser(User user)
        {
            _bookingDbContext.Users.Add(user);
        }

        public void UpdateUser(User user)
        {
            _bookingDbContext.Users.Update(user);
        }

        public void Dispose()
        {
            _bookingDbContext.Dispose();
        }
    }
}