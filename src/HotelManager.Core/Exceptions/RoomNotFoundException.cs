using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Core.Exceptions
{
    public class RoomNotFoundException : UserFriendlyException
    {
        private const string MESSAGE = "Quarto não encontrado.";

        public RoomNotFoundException() : base(MESSAGE) { }
    }
}