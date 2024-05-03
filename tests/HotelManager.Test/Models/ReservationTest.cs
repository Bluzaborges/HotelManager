namespace HotelManager.Test.Models
{
    public class ReservationTest
    {
        public Guid Id { get; set; }
        public int Sequence { get; set; }

        private ReservationTest(int sequence)
        {
            Sequence = sequence;
            Id = Guid.NewGuid();
        }

        public static ReservationTest Create(int sequence)
        {
            return new ReservationTest(sequence);
        }
    }
}