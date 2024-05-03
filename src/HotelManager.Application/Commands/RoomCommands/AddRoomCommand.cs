using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Core.Enums;

namespace HotelManager.Application.Commands.RoomCommands
{
    public class AddRoomCommand : ICommand
    {
        public string? Code { get; set; }
        public RoomType Type { get; set; }
    }
}