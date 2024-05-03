using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Core.Exceptions
{
    public class UserNotFoundException : UserFriendlyException
    {
        private const string MESSAGE = "Usuário não encontrado.";

        public UserNotFoundException() : base(MESSAGE) { }
    }
}