using MediatR;
using HotelManager.Core.Exceptions;
using HotelManager.Domain.Abstractions.Repositories;

namespace HotelManager.Application.Commands.RoomCommands
{
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IReservationRepository _reservationRepository;

        public DeleteRoomCommandHandler(IRoomRepository roomRepository, IReservationRepository reservationRepository)
        {
            _roomRepository = roomRepository;
            _reservationRepository = reservationRepository;
        }

        public async Task Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var room = await _roomRepository.GetRoomByIdAsync(request.IdRoom) ?? throw new RoomNotFoundException();

            var roomReservations = await _reservationRepository.GetAllActiveReservationsByIdRoomAsync(room.Id);

            if (roomReservations.Any())
                throw new ActiveReservationsExistException();

            room.Delete();

            _roomRepository.UpdateRoom(room);

            await _roomRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}