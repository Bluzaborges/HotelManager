using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HotelManager.Core.Enums;
using HotelManager.Query.Application.ViewModels;
using HotelManager.Query.Model.Abstractions.QueryContexts;

namespace HotelManager.Query.Application.Queries.UserQueries
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<UserViewModel>>
    {
        private readonly IQueryContext _context;
        private readonly IMapper _mapper;

        public GetAllCustomersQueryHandler(IMapper mapper, IQueryContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<UserViewModel>>(
                await _context.AllUsers
                    .AsNoTracking()
                    .Where(u => u.Role != UserRole.Admin &&
                                u.Role != UserRole.Attendant &&
                                u.Deleted == false)
                    .ToListAsync());
        }
    }
}