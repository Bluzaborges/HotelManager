using HotelManager.Core.Enums;

namespace HotelManager.Query.Application.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public UserRole Role { get; set; }
        public string? Cpf { get; set; }
        public string? Phone { get; set; }
        public double? Fine { get; set; }
        public bool? Blocked { get; set; }
    }
}