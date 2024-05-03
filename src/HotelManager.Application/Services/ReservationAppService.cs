using HotelManager.Application.Services.Abstractions;
using HotelManager.Domain.Abstractions.Repositories;

namespace HotelManager.Application.Services
{
    public class ReservationAppService : IReservationAppService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationAppService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public bool CheckFine(DateTime startDate)
        {
            if (startDate.Subtract(DateTime.Now).TotalHours > 24)
                return false;

            return true;
        }

        public void Dispose()
        {
            _reservationRepository.Dispose();
        }
    }
}