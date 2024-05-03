using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Core.Exceptions
{
    public class AdminDeletionException : UserFriendlyException
    {
        private const string MESSAGE = "Você não tem permissão para deletar outro administrador.";

        public AdminDeletionException() : base(MESSAGE) { }
    }
}