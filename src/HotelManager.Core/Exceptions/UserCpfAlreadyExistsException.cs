using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Core.Exceptions
{
    public class UserCpfAlreadyExistsException : UserFriendlyException
    {
        private const string MESSAGE = "Um usuário com este CPF já está cadastrado.";

        public UserCpfAlreadyExistsException() : base(MESSAGE) { }
    }
}