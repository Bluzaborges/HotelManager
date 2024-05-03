using HotelManager.Core.Data;
using HotelManager.Core.Enums;
using HotelManager.Domain.Entities;

namespace HotelManager.Domain.Abstractions.Repositories
{
    public interface IRoomValueRepository : IRepository<RoomValue>
    {
        Task<RoomValue?> GetRoomValueByIdAsync(Guid id);

        Task<RoomValue?> GetRoomValueByTypeAsync(RoomType type);

        void UpdateRoomValue(RoomValue roomValue);
    }
}