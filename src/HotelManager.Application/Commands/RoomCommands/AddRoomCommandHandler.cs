using MediatR;
using HotelManager.Core.Exceptions;
using HotelManager.Domain.Abstractions.Repositories;
using HotelManager.Domain.Entities;

namespace HotelManager.Application.Commands.RoomCommands
{
    public class AddRoomCommandHandler : IRequestHandler<AddRoomCommand>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomValueRepository _roomValueRepository;

        public AddRoomCommandHandler(IRoomRepository roomRepository, IRoomValueRepository roomValueRepository)
        {
            _roomRepository = roomRepository;
            _roomValueRepository = roomValueRepository;
        }

        public async Task Handle(AddRoomCommand request, CancellationToken cancellationToken)
        {
            var roomValue = await _roomValueRepository.GetRoomValueByTypeAsync(request.Type) ?? throw new RoomValueNotFoundException();

            if (await _roomRepository.GetRoomByCodeAsync(request.Code) != null)
                throw new RoomCodeAlreadyExistsException();

            var room = Room.Create(roomValue.Id, request.Code);

            _roomRepository.AddRoom(room);

            await _roomRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}