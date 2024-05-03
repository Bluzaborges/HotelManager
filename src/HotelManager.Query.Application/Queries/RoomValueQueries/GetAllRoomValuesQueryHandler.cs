using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HotelManager.Query.Application.ViewModels;
using HotelManager.Query.Model.Abstractions.QueryContexts;

namespace HotelManager.Query.Application.Queries.RoomValueQueries
{
    internal class GetAllRoomValuesQueryHandler : IRequestHandler<GetAllRoomValuesQuery, IEnumerable<RoomValueViewModel>>
    {
        private readonly IQueryContext _context;
        private readonly IMapper _mapper;

        public GetAllRoomValuesQueryHandler(IMapper mapper, IQueryContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoomValueViewModel>> Handle(GetAllRoomValuesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<RoomValueViewModel>>(await _context.AllRoomValues
                .Include(v => v.Rooms)
                .AsNoTracking()
                .ToListAsync()
            );
        }
    }
}