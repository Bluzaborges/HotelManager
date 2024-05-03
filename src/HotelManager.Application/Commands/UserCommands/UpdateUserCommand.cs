using HotelManager.Abstraction.Mediator.Abstractions;

namespace HotelManager.Application.Commands.UserCommands
{
    public class UpdateUserCommand : ICommand
    {
        public Guid IdUser { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Cpf { get; set; }
        public string? Phone { get; set; }
    }
}