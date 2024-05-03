using Microsoft.EntityFrameworkCore;
using HotelManager.Core.Data;
using HotelManager.Core.Enums;
using HotelManager.Data.Contexts;
using HotelManager.Domain.Abstractions.Repositories;
using HotelManager.Domain.Entities;

namespace HotelManager.Data.Repositories
{
    public class RoomValueRepository : IRoomValueRepository
    {
        private readonly BookingDbContext _bookingDbContext;

        public RoomValueRepository(BookingDbContext bookingDbContext)
        {
            _bookingDbContext = bookingDbContext;
        }

        public IUnitOfWork UnitOfWork => _bookingDbContext;

        public async Task<RoomValue?> GetRoomValueByIdAsync(Guid id)
        {
            return await _bookingDbContext.RoomValues.FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<RoomValue?> GetRoomValueByTypeAsync(RoomType type)
        {
            return await _bookingDbContext.RoomValues.FirstOrDefaultAsync(v => v.Type == type);
        }

        public void UpdateRoomValue(RoomValue roomValue)
        {
            _bookingDbContext.RoomValues.Update(roomValue);
        }

        public void Dispose()
        {
            _bookingDbContext.Dispose();
        }
    }
}