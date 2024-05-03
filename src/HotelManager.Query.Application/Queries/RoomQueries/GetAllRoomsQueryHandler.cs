using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HotelManager.Query.Application.ViewModels;
using HotelManager.Query.Model.Abstractions.QueryContexts;

namespace HotelManager.Query.Application.Queries.RoomQueries
{
    public class GetAllRoomsQueryHandler : IRequestHandler<GetAllRoomsQuery, IEnumerable<RoomViewModel>>
    {
        private readonly IQueryContext _context;
        private readonly IMapper _mapper;

        public GetAllRoomsQueryHandler(IMapper mapper, IQueryContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomViewModel>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<RoomViewModel>>(
                await _context.AllRooms
                    .Include(r => r.RoomValue)
                    .Include(r => r.Reservations)
                    .AsNoTracking()
                    .Where(r => !r.Deleted)
                    .ToListAsync()
            );
        }
    }
}