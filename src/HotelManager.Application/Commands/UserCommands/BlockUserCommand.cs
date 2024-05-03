using HotelManager.Abstraction.Mediator.Abstractions;

namespace HotelManager.Application.Commands.UserCommands
{
    public class BlockUserCommand : ICommand
    {
        public Guid IdUser { get; set; }
    }
}