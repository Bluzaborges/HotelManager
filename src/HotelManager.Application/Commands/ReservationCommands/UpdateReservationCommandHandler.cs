using MediatR;
using HotelManager.Abstraction.Exceptions;
using HotelManager.Core.Exceptions;
using HotelManager.Domain.Abstractions.Repositories;

namespace HotelManager.Application.Commands.ReservationCommands
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        public readonly IReservationRepository _reservationRepository;
        public readonly IRoomRepository _roomRepository;

        public UpdateReservationCommandHandler(IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }

        public async Task Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            request.StartDate = new DateTime(request.StartDate.Year, request.StartDate.Month, request.StartDate.Day, 12, 0, 0);
            request.EndDate = new DateTime(request.EndDate.Year, request.EndDate.Month, request.EndDate.Day, 12, 0, 0);

            var rooms = await _roomRepository.GetAllAvailableRoomsAsync(request.IdReservation, request.StartDate, request.EndDate, request.Type);

            if (!rooms.Any())
                throw new NotDisponibleRoomException();

            var room = rooms.First();

            if (room.RoomValue == null)
                throw new InternalException();

            var reservation = await _reservationRepository.GetReservationByIdAsync(request.IdReservation, request.IdUser) ?? throw new ReservationNotFoundException();

            reservation.Update(request.StartDate, request.EndDate, room.Id);

            reservation.CalculateValue(room.RoomValue.Value);

            _reservationRepository.UpdateReservation(reservation);

            await _reservationRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}