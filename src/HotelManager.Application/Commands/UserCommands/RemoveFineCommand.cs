using HotelManager.Abstraction.Mediator.Abstractions;

namespace HotelManager.Application.Commands.UserCommands
{
    public class RemoveFineCommand : ICommand
    {
        public Guid IdUser { get; set; }
    }
}