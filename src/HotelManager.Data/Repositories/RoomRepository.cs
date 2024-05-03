using Microsoft.EntityFrameworkCore;
using HotelManager.Core.Data;
using HotelManager.Core.Enums;
using HotelManager.Data.Contexts;
using HotelManager.Domain.Abstractions.Repositories;
using HotelManager.Domain.Entities;

namespace HotelManager.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly BookingDbContext _bookingDbContext;
        
        public RoomRepository(BookingDbContext bookingDbContext)
        {
            _bookingDbContext = bookingDbContext;
        }

        public IUnitOfWork UnitOfWork => _bookingDbContext;

        public async Task<Room?> GetRoomByIdAsync(Guid id)
        {
            return await _bookingDbContext.Rooms.FirstOrDefaultAsync(r => r.Id == id && r.Deleted == false);
        }

        public async Task<Room?> GetRoomByCodeAsync(string? code)
        {
            return await _bookingDbContext.Rooms.FirstOrDefaultAsync(r => r.Code == code && r.Deleted == false);
        }

        public async Task<IEnumerable<Room>> GetAllAvailableRoomsAsync(DateTime startDate, DateTime endDate, RoomType type)
        {
            return await _bookingDbContext.Rooms
                .Include(r => r.RoomValue)
                .Where(r => r.RoomValue != null &&
                            r.RoomValue.Type == type &&
                            r.Deleted == false &&
                            !_bookingDbContext.Reservations
                                .Any(res => res.IdRoom == r.Id &&
                                    (res.StartDate <= startDate || res.StartDate <= endDate) &&
                                    (res.EndDate >= startDate || res.EndDate >= endDate) &&
                                    res.Deleted == false))
                .ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetAllAvailableRoomsAsync(Guid idReservation, DateTime startDate, DateTime endDate, RoomType type)
        {
            return await _bookingDbContext.Rooms
                .Include(r => r.RoomValue)
                .Where(r => r.RoomValue != null &&
                            r.RoomValue.Type == type &&
                            r.Deleted == false &&
                            !_bookingDbContext.Reservations
                                .Any(res => res.IdRoom == r.Id &&
                                            (res.StartDate <= startDate || res.StartDate <= endDate) &&
                                            (res.EndDate >= startDate || res.EndDate >= endDate) &&
                                            res.Deleted == false &&
                                            res.Id != idReservation))
                .ToListAsync();
        }


        public void AddRoom(Room room)
        {
            _bookingDbContext.Rooms.Add(room);
        }

        public void UpdateRoom(Room room)
        {
            _bookingDbContext.Rooms.Update(room);
        }

        public void Dispose()
        {
            _bookingDbContext.Dispose();
        }
    }
}