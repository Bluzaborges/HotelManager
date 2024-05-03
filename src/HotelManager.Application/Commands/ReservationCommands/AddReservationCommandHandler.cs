using MediatR;
using HotelManager.Core.Exceptions;
using HotelManager.Abstraction.Exceptions;
using HotelManager.Domain.Abstractions.Repositories;
using HotelManager.Domain.Entities;

namespace HotelManager.Application.Commands.ReservationCommands
{
    public class AddReservationCommandHandler : IRequestHandler<AddReservationCommand>
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;

        public AddReservationCommandHandler(IReservationRepository reservationRepository, IRoomRepository roomRepository)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
        }

        public async Task Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            request.StartDate = new DateTime(request.StartDate.Year, request.StartDate.Month, request.StartDate.Day, 12, 0, 0);
            request.EndDate = new DateTime(request.EndDate.Year, request.EndDate.Month, request.EndDate.Day, 12, 0, 0);

            var rooms = await _roomRepository.GetAllAvailableRoomsAsync(request.StartDate, request.EndDate, request.Type);

            if (!rooms.Any())
                throw new NotDisponibleRoomException();

            var room = rooms.First();

            if (room.RoomValue == null)
                throw new InternalException();

            var reservation = Reservation.Create(request.IdUser, room.Id, request.StartDate, request.EndDate);

            reservation.CalculateValue(room.RoomValue.Value);

            _reservationRepository.AddReservation(reservation);

            await _reservationRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}