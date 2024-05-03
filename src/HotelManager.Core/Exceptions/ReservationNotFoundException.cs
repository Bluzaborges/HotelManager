using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Core.Exceptions
{
    public class ReservationNotFoundException : UserFriendlyException
    {
        private const string MESSAGE = "Reserva não encontrada.";

        public ReservationNotFoundException() : base(MESSAGE) { }
    }
}