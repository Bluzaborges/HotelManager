using HotelManager.Abstraction.Mediator.Abstractions;

namespace HotelManager.Application.Commands.RoomValueCommands
{
    public class UpdateRoomValueCommand : ICommand
    {
        public Guid IdRoomValue { get; set; }
        public string? Name { get; set; }
        public double Value { get; set; }
    }
}