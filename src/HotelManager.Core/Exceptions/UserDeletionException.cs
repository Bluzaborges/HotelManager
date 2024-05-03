using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Core.Exceptions
{
    public class UserDeletionException : UserFriendlyException
    {
        private const string MESSAGE = "Você não tem permissão para deletar usuários.";

        public UserDeletionException() : base(MESSAGE) { }
    }
}