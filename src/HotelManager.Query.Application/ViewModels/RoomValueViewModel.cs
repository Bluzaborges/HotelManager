using HotelManager.Core.Enums;

namespace HotelManager.Query.Application.ViewModels
{
    public class RoomValueViewModel
    {
        public Guid Id { get; set; }
        public RoomType Type { get; set; }
        public string? Name { get; set; }
        public double Value { get; set; }
        public int RoomsCount { get; set; }
    }
}