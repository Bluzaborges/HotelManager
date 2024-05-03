using HotelManager.Core.Enums;

namespace HotelManager.Test.Models
{
    public class RoomTest
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public RoomType Type { get; set; }
        public RoomValueTest? RoomValue { get; set; }

        private RoomTest(string code, RoomValueTest roomValue)
        {
            Id = Guid.NewGuid();
            Code = code;
            RoomValue = roomValue;
        }

        private RoomTest(string code, RoomType type)
        {
            Id = Guid.NewGuid();
            Code = code;
            Type = type;
        }

        public static RoomTest Create(string code, RoomValueTest roomValue)
        {
            return new RoomTest(code, roomValue);
        }

        public static RoomTest Create(string code, RoomType type)
        {
            return new RoomTest(code, type);
        }
    }
}