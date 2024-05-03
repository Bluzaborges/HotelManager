using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Core.Exceptions
{
    public class RoomValueNotFoundException : UserFriendlyException
    {
        private const string MESSAGE = "Não foi possível identificar o tipo do quarto.";

        public RoomValueNotFoundException() : base(MESSAGE) { }
    }
}