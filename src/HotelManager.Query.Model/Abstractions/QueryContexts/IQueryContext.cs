using HotelManager.Query.Model.Models;

namespace HotelManager.Query.Model.Abstractions.QueryContexts
{
    public interface IQueryContext
    {
        IQueryable<Reservation> AllReservations { get; }

        IQueryable<User> AllUsers { get; }

        IQueryable<Room> AllRooms { get; }

        IQueryable<RoomValue> AllRoomValues { get; }
    }
}