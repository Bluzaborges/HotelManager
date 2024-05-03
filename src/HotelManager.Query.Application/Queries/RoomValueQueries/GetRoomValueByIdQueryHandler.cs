using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HotelManager.Query.Application.ViewModels;
using HotelManager.Query.Model.Abstractions.QueryContexts;

namespace HotelManager.Query.Application.Queries.RoomValueQueries
{
    public class GetRoomValueByIdQueryHandler : IRequestHandler<GetRoomValueByIdQuery, RoomValueViewModel>
    {
        private readonly IQueryContext _context;
        private readonly IMapper _mapper;

        public GetRoomValueByIdQueryHandler(IMapper mapper, IQueryContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RoomValueViewModel> Handle(GetRoomValueByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<RoomValueViewModel>(
                await _context.AllRoomValues
                    .FirstOrDefaultAsync(v => v.Id == request.IdRoomValue)
            );
        }
    }
}