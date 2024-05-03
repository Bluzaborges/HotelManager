using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Core.Enums;

namespace HotelManager.Application.Commands.UserCommands
{
    public class AddUserCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; }
        public string? Cpf { get; set; }
        public string? Phone { get; set; }
    }
}