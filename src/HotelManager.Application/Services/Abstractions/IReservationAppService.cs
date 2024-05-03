namespace HotelManager.Application.Services.Abstractions
{
    public interface IReservationAppService : IDisposable
    {
        bool CheckFine(DateTime startDate);
    }
}