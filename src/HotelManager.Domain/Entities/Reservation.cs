using HotelManager.Core.Domain;
using HotelManager.Core.Exceptions;

namespace HotelManager.Domain.Entities
{
    public class Reservation : Entity
    {
        public Guid IdUser { get; private set; }
        public Guid IdRoom { get; private set; }
        public double Value { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public bool Deleted { get; private set; }
        public User? User { get; private set; }
        public Room? Room { get; private set; }

        protected Reservation() { }

        private Reservation(Guid idUser, Guid idRoom, DateTime startDate, DateTime endDate)
        {
            IdUser = idUser;
            IdRoom = idRoom;
            StartDate = startDate;
            EndDate = endDate;

            Validations();
        }

        public static Reservation Create(Guid idUser, Guid idRoom, DateTime startDate, DateTime endDate)
        {
            return new Reservation(idUser, idRoom, startDate, endDate);
        }

        public void Update(DateTime startDate, DateTime endDate, Guid idRoom)
        {
            IdRoom = idRoom;
            StartDate = startDate;
            EndDate = endDate;

            Validations();
        }

        public void CalculateValue(double roomValue)
        {
            double days = (EndDate - StartDate).TotalDays;

            Value = days * roomValue;

            AssertionHelper.ArgumentLessThanOrEqual(Value, 0, "O valor da reserva não pode igual ou menor a zero.");
        }

        public void Cancel()
        {
            Deleted = true;
        }

        private void Validations()
        {
            AssertionHelper.ArgumentLessThanOrEqual(EndDate, StartDate, "A data final da reserva não pode ser menor ou igual a data inicial.");
            AssertionHelper.ArgumentLessThan(StartDate.Date, DateTime.Now.Date, "A data inicial não pode ser menor que a data atual.");
            AssertionHelper.ArgumentLessThanOrEqual(EndDate, DateTime.Now, "A data final não pode ser menor ou igual a data atual");
            AssertionHelper.ArgumentGraterThan(StartDate, DateTime.Now.AddYears(1), "Uma reserva só pode ser realizada em uma janela de 1 ano a partir da data atual.");
            AssertionHelper.ArgumentGraterThan(EndDate, StartDate.AddMonths(1), "O período máximo de uma reserva é de 1 mês.");
        }
    }
}