using MediatR;
using HotelManager.Security.Authentication;
using HotelManager.Core.Exceptions;
using HotelManager.Domain.Abstractions.Repositories;
using HotelManager.Domain.Services.Abstractions;

namespace HotelManager.Application.Commands.UserCommands
{
    public class SignInCommandHandler : IRequestHandler<SignInCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public SignInCommandHandler(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        public async Task<string> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var password = _userService.EncryptPassword(request.Password);

            var user = await _userRepository.GetUserByEmailPasswordAsync(request.Email, password) ?? throw new InvalidEmailPasswordException();

            if (user.Blocked)
                throw new UserBlockedException();

            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
                throw new InvalidEmailPasswordException();

            var token = Token.GetJwtToken(user.Id, user.Name, user.Email, (int)user.Role);

            return token;
        }
    }
}