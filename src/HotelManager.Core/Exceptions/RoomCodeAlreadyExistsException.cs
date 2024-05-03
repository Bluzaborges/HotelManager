using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Core.Exceptions
{
    public class RoomCodeAlreadyExistsException : UserFriendlyException
    {
        private const string MESSAGE = "Um quarto com este código já está cadastrado.";

        public RoomCodeAlreadyExistsException() : base(MESSAGE) { }
    }
}