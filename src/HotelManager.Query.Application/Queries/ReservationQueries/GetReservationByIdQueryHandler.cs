using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HotelManager.Query.Application.ViewModels;
using HotelManager.Query.Model.Abstractions.QueryContexts;

namespace HotelManager.Query.Application.Queries.ReservationQueries
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, ReservationViewModel>
    {
        private readonly IQueryContext _context;
        private readonly IMapper _mapper;

        public GetReservationByIdQueryHandler(IMapper mapper, IQueryContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ReservationViewModel> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ReservationViewModel>(
                await _context.AllReservations
                    .Include(res => res.Room != null ? res.Room.RoomValue : null)
                    .FirstOrDefaultAsync(res => res.Id == request.IdReservation &&
                                                  res.User != null &&
                                                  res.User.Id == request.IdUser &&
                                                  res.Deleted == false &&
                                                  res.Room != null));
        }
    }
}