using Microsoft.EntityFrameworkCore;
using HotelManager.Core.Data;
using HotelManager.Data.Contexts;
using HotelManager.Domain.Abstractions.Repositories;
using HotelManager.Domain.Entities;

namespace HotelManager.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly BookingDbContext _bookingDbContext;

        public ReservationRepository(BookingDbContext bookingDbContext)
        {
            _bookingDbContext = bookingDbContext;
        }

        public IUnitOfWork UnitOfWork => _bookingDbContext;

        public async Task<Reservation?> GetReservationByIdAsync(Guid idReservation, Guid idUser)
        {
            return await _bookingDbContext.Reservations.FirstOrDefaultAsync(res => res.Id == idReservation && res.IdUser == idUser);
        }

        public async Task<IEnumerable<Reservation>> GetAllReservationsByIdUserAsync(Guid idUser)
        {
            return await _bookingDbContext.Reservations
                .AsNoTracking()
                .Where(res => res.IdUser == idUser &&
                              res.Deleted == false)
                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetAllActiveReservationsByIdRoomAsync(Guid idRoom)
        {
            return await _bookingDbContext.Reservations
                .AsNoTracking()
                .Where(res => res.IdRoom == idRoom &&
                              res.EndDate >= DateTime.Now &&
                              res.Deleted == false)
                .ToListAsync();
        }

        public void AddReservation(Reservation reservation)
        {
            _bookingDbContext.Reservations.Add(reservation);
        }

        public void UpdateReservation(Reservation reservation)
        {
            _bookingDbContext.Reservations.Update(reservation);
        }

        public void Dispose()
        {
            _bookingDbContext.Dispose();
        }
    }
}