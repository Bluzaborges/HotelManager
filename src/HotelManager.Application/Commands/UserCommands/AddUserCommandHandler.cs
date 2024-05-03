using MediatR;
using HotelManager.Core.Exceptions;
using HotelManager.Domain.Abstractions.Repositories;
using HotelManager.Domain.Services.Abstractions;
using HotelManager.Domain.Entities;

namespace HotelManager.Application.Commands.UserCommands
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public AddUserCommandHandler(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetUserByCpfAsync(request.IdUser, request.Cpf) != null)
                throw new UserCpfAlreadyExistsException();

            if (await _userRepository.GetUserByEmailAsync(request.IdUser, request.Email) != null)
                throw new UserEmailAlreadyExistsException();

            var user = User.Create(request.Name, request.Email, request.Password, request.Role, request.Cpf, request.Phone);

            user.UpdatePassword(_userService.EncryptPassword(user.Password));

            _userRepository.AddUser(user);

            await _userRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}