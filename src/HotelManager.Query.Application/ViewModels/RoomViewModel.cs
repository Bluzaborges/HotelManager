namespace HotelManager.Query.Application.ViewModels
{
    public class RoomViewModel
    {
        public Guid Id { get; set; }
        public string? Code { get; set; }
        public int ReservationsCount { get; set; }
        public RoomValueViewModel? RoomValue { get; set; }
    }
}