using HotelManager.Core.Model;

namespace HotelManager.Query.Model.Models
{
    public class Room : DtoBase
    {
        public string? Code { get; set; }
        public bool Deleted { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
        public RoomValue? RoomValue { get; set; }
    }
}