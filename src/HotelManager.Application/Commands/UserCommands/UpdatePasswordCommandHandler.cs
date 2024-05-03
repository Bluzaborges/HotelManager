using MediatR;
using HotelManager.Abstraction.Exceptions;
using HotelManager.Domain.Abstractions.Repositories;
using HotelManager.Domain.Services.Abstractions;

namespace HotelManager.Application.Commands.UserCommands
{
    public class UpdatePasswordCommandHandler : IRequestHandler<UpdatePasswordCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UpdatePasswordCommandHandler(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.IdUser) ?? throw new InternalException();

            var encryptedPassword = _userService.EncryptPassword(request.Password);

            user.UpdatePassword(encryptedPassword);

            _userRepository.UpdateUser(user);

            await _userRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}