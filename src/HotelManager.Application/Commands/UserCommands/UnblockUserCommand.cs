using HotelManager.Abstraction.Mediator.Abstractions;

namespace HotelManager.Application.Commands.UserCommands
{
    public class UnblockUserCommand : ICommand
    {
        public Guid IdUser { get; set; }
    }
}