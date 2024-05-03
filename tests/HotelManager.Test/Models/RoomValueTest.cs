using HotelManager.Core.Enums;

namespace HotelManager.Test.Models
{
    public class RoomValueTest
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public RoomType Type { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }

        private RoomValueTest(int number, RoomType type, string name, double value)
        {
            Id = Guid.NewGuid();
            Number = number;
            Value = value;
            Type = type;
            Name = name;
        }

        public static RoomValueTest Create(int number, RoomType type, string name, double value)
        {
            return new RoomValueTest(number, type, name, value);
        }
    }
}