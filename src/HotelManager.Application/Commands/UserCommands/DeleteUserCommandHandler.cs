using MediatR;
using HotelManager.Core.Exceptions;
using HotelManager.Core.Enums;
using HotelManager.Domain.Abstractions.Repositories;

namespace HotelManager.Application.Commands.UserCommands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IReservationRepository _reservationRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository, IReservationRepository reservationRepository)
        {
            _userRepository = userRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Role != UserRole.Admin)
                throw new UserDeletionException();

            var user = await _userRepository.GetUserByIdAsync(request.IdUser) ?? throw new UserNotFoundException();

            if (user.Role == UserRole.Admin)
                throw new AdminDeletionException();

            user.Delete();

            _userRepository.UpdateUser(user);

            await _userRepository.UnitOfWork.SaveChangesAsync();

            var reservations = await _reservationRepository.GetAllReservationsByIdUserAsync(request.IdUser);

            foreach (var reservation in reservations)
            {
                reservation.Cancel();
                _reservationRepository.UpdateReservation(reservation);
            }

            await _reservationRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}