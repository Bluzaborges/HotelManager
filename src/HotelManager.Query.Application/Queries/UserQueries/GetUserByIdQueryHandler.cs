using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HotelManager.Query.Application.ViewModels;
using HotelManager.Query.Model.Abstractions.QueryContexts;

namespace HotelManager.Query.Application.Queries.UserQueries
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IQueryContext _context;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IMapper mapper, IQueryContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<UserViewModel>(
                await _context.AllUsers
                    .FirstOrDefaultAsync(u => u.Id == request.IdUser && u.Deleted == false)
            );
        }
    }
}