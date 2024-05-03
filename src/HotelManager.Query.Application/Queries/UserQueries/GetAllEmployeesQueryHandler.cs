using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HotelManager.Core.Enums;
using HotelManager.Query.Application.ViewModels;
using HotelManager.Query.Model.Abstractions.QueryContexts;

namespace HotelManager.Query.Application.Queries.UserQueries
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<UserViewModel>>
    {
        private readonly IQueryContext _context;
        private readonly IMapper _mapper;

        public GetAllEmployeesQueryHandler(IMapper mapper, IQueryContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(
                await _context.AllUsers
                    .AsNoTracking()
                    .Where(u => u.Id != request.IdUser &&
                                u.Role != UserRole.Customer &&
                                u.Deleted == false)
                    .ToListAsync());
        }
    }
}