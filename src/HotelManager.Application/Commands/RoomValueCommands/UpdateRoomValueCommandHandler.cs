using MediatR;
using HotelManager.Abstraction.Exceptions;
using HotelManager.Domain.Abstractions.Repositories;

namespace HotelManager.Application.Commands.RoomValueCommands
{
    public class UpdateRoomValueCommandHandler : IRequestHandler<UpdateRoomValueCommand>
    {
        private readonly IRoomValueRepository _roomValueRepository;

        public UpdateRoomValueCommandHandler(IRoomValueRepository roomValueRepository)
        {
            _roomValueRepository = roomValueRepository;
        }

        public async Task Handle(UpdateRoomValueCommand request, CancellationToken cancellationToken)
        {
            var roomValue = await _roomValueRepository.GetRoomValueByIdAsync(request.IdRoomValue) ?? throw new InternalException();

            double teste = Convert.ToDouble(request.Value);

            roomValue.Update(request.Name, teste);

            _roomValueRepository.UpdateRoomValue(roomValue);

            await _roomValueRepository.UnitOfWork.SaveChangesAsync();
        }
    }
}