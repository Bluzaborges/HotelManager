using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Core.Exceptions
{
    public class InvalidEmailPasswordException : UserFriendlyException
    {
        private const string MESSAGE = "E-mail ou senha incorretos.";

        public InvalidEmailPasswordException() : base(MESSAGE) { }
    }
}