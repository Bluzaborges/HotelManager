using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HotelManager.Query.Application.ViewModels;
using HotelManager.Query.Model.Abstractions.QueryContexts;

namespace HotelManager.Query.Application.Queries.ReservationQueries
{
    public class GetAllReservationsQueryHandler : IRequestHandler<GetAllReservationsQuery, IEnumerable<ReservationViewModel>>
    {
        private readonly IQueryContext _context;
        private readonly IMapper _mapper;

        public GetAllReservationsQueryHandler(IMapper mapper, IQueryContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReservationViewModel>> Handle(GetAllReservationsQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<ReservationViewModel>>(
                await _context.AllReservations
                    .AsNoTracking()
                    .Include(res => res.Room != null ? res.Room.RoomValue : null)
                    .Where(res => res.User != null &&
                                  res.User.Id == request.IdUser &&
                                  res.EndDate >= DateTime.Now &&
                                  res.Deleted == false &&
                                  res.Room != null)
                    .ToListAsync());
        }
    }
}