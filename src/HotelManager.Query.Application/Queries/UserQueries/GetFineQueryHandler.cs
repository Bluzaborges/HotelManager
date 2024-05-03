using MediatR;
using Microsoft.EntityFrameworkCore;
using HotelManager.Abstraction.Exceptions;
using HotelManager.Query.Model.Abstractions.QueryContexts;

namespace HotelManager.Query.Application.Queries.UserQueries
{
    public class GetFineQueryHandler : IRequestHandler<GetFineQuery, double>
    {
        private readonly IQueryContext _context;

        public GetFineQueryHandler(IQueryContext context)
        {
            _context = context;
        }

        public async Task<double> Handle(GetFineQuery request, CancellationToken cancellationToken)
        {
            var user = await _context.AllUsers.FirstOrDefaultAsync(u => u.Id == request.IdUser && u.Deleted == false);

            return user == null ? throw new InternalException() : user.Fine;
        }
    }
}