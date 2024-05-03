using HotelManager.Abstraction.Mediator.Abstractions;

namespace HotelManager.Query.Application.Queries.UserQueries
{
    public class GetFineQuery : ICommand<double>
    {
        public Guid IdUser { get; set; }
    }
}