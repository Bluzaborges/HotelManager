using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Core.Enums;

namespace HotelManager.Application.Commands.UserCommands
{
    public class DeleteUserCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public UserRole Role { get; set; }
    }
}