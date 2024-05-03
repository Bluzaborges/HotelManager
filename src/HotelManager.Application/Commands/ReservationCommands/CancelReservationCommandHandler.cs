using MediatR;
using HotelManager.Abstraction.Exceptions;
using HotelManager.Core.Exceptions;
using HotelManager.Application.Services.Abstractions;
using HotelManager.Domain.Abstractions.Repositories;

namespace HotelManager.Application.Commands.ReservationCommands
{
    public class CancelReservationCommandHandler : IRequestHandler<CancelReservationCommand>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IReservationAppService _reservationAppService;

        public CancelReservationCommandHandler(IReservationRepository reservationRepository, IUserRepository userRepository, IReservationAppService reservationAppService)
        {
            _reservationRepository = reservationRepository;
            _userRepository = userRepository;
            _reservationAppService = reservationAppService;
        }

        public async Task Handle(CancelReservationCommand request, CancellationToken cancellationToken)
        {
            if (request.IdReservation == Guid.Empty || request.IdUser == Guid.Empty)
                throw new ReservationNotFoundException();

            var reservation = await _reservationRepository.GetReservationByIdAsync(request.IdReservation, request.IdUser) ?? throw new ReservationNotFoundException();

            if (_reservationAppService.CheckFine(reservation.StartDate))
            {
                var user = await _userRepository.GetUserByIdAsync(request.IdUser) ?? throw new InternalException();

                user.AddFine(reservation.Value * 0.2);

                _userRepository.UpdateUser(user);

                await _userRepository.UnitOfWork.SaveChangesAsync();
            }

            reservation.Cancel();

            _reservationRepository.UpdateReservation(reservation);

            await _reservationRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}