using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Query.Application.ViewModels;

namespace HotelManager.Query.Application.Queries.ReservationQueries
{
    public class GetReservationByIdQuery : ICommand<ReservationViewModel>
    {
        public Guid IdReservation { get; set; }
        public Guid IdUser { get; set; }
    }
}