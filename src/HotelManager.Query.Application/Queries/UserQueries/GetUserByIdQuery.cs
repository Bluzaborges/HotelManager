using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Query.Application.ViewModels;

namespace HotelManager.Query.Application.Queries.UserQueries
{
    public class GetUserByIdQuery : ICommand<UserViewModel>
    {
        public Guid IdUser { get; set; }
    }
}