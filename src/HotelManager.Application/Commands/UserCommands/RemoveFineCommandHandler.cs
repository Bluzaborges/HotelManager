using MediatR;
using HotelManager.Core.Exceptions;
using HotelManager.Domain.Abstractions.Repositories;

namespace HotelManager.Application.Commands.UserCommands
{
    public class RemoveFineCommandHandler : IRequestHandler<RemoveFineCommand>
    {
        private readonly IUserRepository _userRepository;

        public RemoveFineCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(RemoveFineCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.IdUser) ?? throw new UserNotFoundException();

            user.RemoveFine();

            _userRepository.UpdateUser(user);

            await _userRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}