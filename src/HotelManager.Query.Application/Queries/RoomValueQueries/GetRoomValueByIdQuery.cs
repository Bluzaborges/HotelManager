using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Query.Application.ViewModels;

namespace HotelManager.Query.Application.Queries.RoomValueQueries
{
    public class GetRoomValueByIdQuery : ICommand<RoomValueViewModel>
    {
        public Guid IdRoomValue { get; set; }
    }
}