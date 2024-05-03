using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Query.Application.ViewModels;

namespace HotelManager.Query.Application.Queries.RoomQueries
{
    public class GetAllRoomsQuery : ICommand<IEnumerable<RoomViewModel>>
    {

    }
}