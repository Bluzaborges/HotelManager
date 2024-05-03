using MediatR;
using HotelManager.Abstraction.Exceptions;
using HotelManager.Core.Exceptions;
using HotelManager.Domain.Abstractions.Repositories;

namespace HotelManager.Application.Commands.UserCommands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            if (await _userRepository.GetUserByCpfAsync(request.IdUser, request.Cpf) != null)
                throw new UserCpfAlreadyExistsException();

            if (await _userRepository.GetUserByEmailAsync(request.IdUser, request.Email) != null)
                throw new UserEmailAlreadyExistsException();

            var user = await _userRepository.GetUserByIdAsync(request.IdUser) ?? throw new InternalException();

            user.Update(request.Name, request.Cpf, request.Email, request.Phone);

            _userRepository.UpdateUser(user);

            await _userRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}