using HotelManager.Query.Model.Models;
using HotelManager.Query.Model.Abstractions.QueryContexts;
using HotelManager.Query.Data.Contexts;

namespace HotelManager.Query.Data.QueryContext
{
    public class HotelManagerQueryContext : IQueryContext
    {
        private readonly HotelManagerQueryDbContext _context;

        public HotelManagerQueryContext(HotelManagerQueryDbContext context)
        {
            _context = context;
        }

        public IQueryable<Reservation> AllReservations
        {
            get
            {
                return _context.Reservations;
            }
        }

        public IQueryable<User> AllUsers
        {
            get
            {
                return _context.Users;
            }
        }

        public IQueryable<Room> AllRooms => _context.Rooms;

        public IQueryable<RoomValue> AllRoomValues
        {
            get
            {
                return _context.RoomValues;
            }
        }
    }
}