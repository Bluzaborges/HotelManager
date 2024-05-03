using HotelManager.Core.Data;
using HotelManager.Domain.Entities;

namespace HotelManager.Domain.Abstractions.Repositories
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task<Reservation?> GetReservationByIdAsync(Guid idReservation, Guid idUser);

        Task<IEnumerable<Reservation>> GetAllReservationsByIdUserAsync(Guid idUser);

        Task<IEnumerable<Reservation>> GetAllActiveReservationsByIdRoomAsync(Guid idRoom);

        void AddReservation(Reservation reservation);

        void UpdateReservation(Reservation reservation);
    }
}