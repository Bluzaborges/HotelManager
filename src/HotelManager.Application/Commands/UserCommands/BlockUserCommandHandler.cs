using MediatR;
using HotelManager.Core.Exceptions;
using HotelManager.Domain.Abstractions.Repositories;

namespace HotelManager.Application.Commands.UserCommands
{
    public class BlockUserCommandHandler : IRequestHandler<BlockUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public BlockUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(BlockUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(request.IdUser) ?? throw new UserNotFoundException();

            user.Block();

            _userRepository.UpdateUser(user);

            await _userRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}