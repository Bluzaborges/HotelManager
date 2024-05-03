using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Core.Enums;

namespace HotelManager.Application.Commands.ReservationCommands
{
    public class AddReservationCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public RoomType Type { get; set; }
    }
}