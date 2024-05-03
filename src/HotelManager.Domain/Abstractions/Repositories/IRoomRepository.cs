using HotelManager.Core.Data;
using HotelManager.Core.Enums;
using HotelManager.Domain.Entities;

namespace HotelManager.Domain.Abstractions.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room?> GetRoomByIdAsync(Guid id);

        Task<Room?> GetRoomByCodeAsync(string? code);

        Task<IEnumerable<Room>> GetAllAvailableRoomsAsync(DateTime startDate, DateTime endDate, RoomType type);

        Task<IEnumerable<Room>> GetAllAvailableRoomsAsync(Guid idReservation, DateTime startDate, DateTime endDate, RoomType type);

        void AddRoom(Room room);

        void UpdateRoom(Room room);
    }
}