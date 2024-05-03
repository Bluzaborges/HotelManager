namespace HotelManager.Query.Application.ViewModels
{
    public class ReservationViewModel
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Value { get; set; }
        public UserViewModel? User { get; set; }
        public RoomViewModel? Room { get; set; }
    }
}