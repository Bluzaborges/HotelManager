using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Core.Exceptions
{
    public class UserBlockedException : UserFriendlyException
    {
        private const string MESSAGE = "Seu usuário está bloqueado. Entre em contato com a administração do sistema.";

        public UserBlockedException() : base(MESSAGE) { }
    }
}