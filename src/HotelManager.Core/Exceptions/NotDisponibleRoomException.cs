using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Core.Exceptions
{
    public class NotDisponibleRoomException : UserFriendlyException
    {
        private const string MESSAGE = "Não há quartos disponíveis no período e tipo de quarto desejado.";

        public NotDisponibleRoomException() : base(MESSAGE) { }
    }
}