using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Core.Exceptions
{
    public class ActiveReservationsExistException : UserFriendlyException
    {
        private const string MESSAGE = "O quarto possui reservas ativas e não pode ser excluído.";

        public ActiveReservationsExistException() : base(MESSAGE) { }
    }
}