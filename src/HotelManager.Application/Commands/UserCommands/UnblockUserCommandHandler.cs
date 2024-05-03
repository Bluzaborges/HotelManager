using MediatR;
using HotelManager.Core.Exceptions;
using HotelManager.Domain.Abstractions.Repositories;

namespace HotelManager.Application.Commands.UserCommands
{
    public class UnblockUserCommandHandler : IRequestHandler<UnblockUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UnblockUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UnblockUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.IdUser) ?? throw new UserNotFoundException();

            user.Unblock();

            _userRepository.UpdateUser(user);

            await _userRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}