using HotelManager.Abstraction.Mediator.Abstractions;

namespace HotelManager.Application.Commands.ReservationCommands
{
    public class CancelReservationCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public Guid IdReservation { get; set; }
    }
}