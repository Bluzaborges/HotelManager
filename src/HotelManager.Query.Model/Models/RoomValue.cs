using HotelManager.Core.Model;
using HotelManager.Core.Enums;

namespace HotelManager.Query.Model.Models
{
    public class RoomValue : DtoBase
    {
        public RoomType Type { get; set; }
        public double Value { get; set; }
        public string? Name { get; set; }
        public ICollection<Room>? Rooms { get; set; }
    }
}