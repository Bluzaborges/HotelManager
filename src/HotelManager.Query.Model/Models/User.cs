using HotelManager.Core.Model;
using HotelManager.Core.Enums;

namespace HotelManager.Query.Model.Models
{
    public class User : DtoBase
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public UserRole Role { get; set; }
        public string? Cpf { get; set; }
        public string? Phone { get; set; }
        public double Fine { get; set; }
        public bool Blocked { get; set; }
        public bool Deleted { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}