using HotelManager.Core.Enums;

namespace HotelManager.Test.Models
{
    public class UserTest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; }
        public string? Cpf { get; set; }
        public string? Phone { get; set; }

        private UserTest(string name, string email, string password, UserRole role, string cpf, string phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Role = role;
            Email = email;
            Password = password;
            Cpf = cpf;
            Phone = phone;
        }

        public static UserTest Create(string name, string email, string password, UserRole role, string cpf, string phone)
        {
            return new UserTest(name, email, password, role, cpf, phone);
        }
    }
}