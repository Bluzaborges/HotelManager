using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Core.Exceptions
{
    public class UserEmailAlreadyExistsException : UserFriendlyException
    {
        private const string MESSAGE = "Um usuário com este e-mail já está cadastrado";

        public UserEmailAlreadyExistsException() : base(MESSAGE) { }
    }
}