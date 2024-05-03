using HotelManager.Core.Model;

namespace HotelManager.Query.Model.Models
{
    public class Reservation : DtoBase
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double Value { get; set; }
        public bool Deleted { get; set; }
        public User? User { get; set; }
        public Room? Room { get; set; }
    }
}