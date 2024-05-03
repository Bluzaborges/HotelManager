using HotelManager.Abstraction.Mediator.Abstractions;

namespace HotelManager.Application.Commands.RoomCommands
{
    public class DeleteRoomCommand : ICommand
    {
        public Guid IdRoom { get; set; }
    }
}