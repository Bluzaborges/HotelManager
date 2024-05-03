using HotelManager.Abstraction.Mediator.Abstractions;

namespace HotelManager.Application.Commands.UserCommands
{
    public class UpdatePasswordCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public string? Password { get; set; }
    }
}