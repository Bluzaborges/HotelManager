using HotelManager.Abstraction.Mediator.Abstractions;

namespace HotelManager.Application.Commands.UserCommands
{
    public class SignInCommand : ICommand<string>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}