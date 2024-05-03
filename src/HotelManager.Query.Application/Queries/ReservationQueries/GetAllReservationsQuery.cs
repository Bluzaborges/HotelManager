using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Query.Application.ViewModels;

namespace HotelManager.Query.Application.Queries.ReservationQueries
{
    public class GetAllReservationsQuery : ICommand<IEnumerable<ReservationViewModel>>
    {
        public Guid IdUser { get; set; }
    }
}