using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Query.Application.ViewModels;

namespace HotelManager.Query.Application.Queries.UserQueries
{
    public class GetAllEmployeesQuery : ICommand<IEnumerable<UserViewModel>>
    {
        public Guid IdUser { get; set; }
    }
}