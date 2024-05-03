using HotelManager.Core.Domain;
using HotelManager.Core.Exceptions;

namespace HotelManager.Domain.Entities
{
    public class Room : Entity
    {
        public Guid IdRoomValue { get; private set; }
        public string? Code { get; private set; }
        public bool Deleted { get; private set; }
        public RoomValue? RoomValue { get; private set; }

        protected Room() { }

        private Room(Guid idRoomValue, string? code)
        {
            IdRoomValue = idRoomValue;
            Code = code;

            Validations();
        }

        public static Room Create(Guid idRoomValue, string? code)
        {
            return new Room(idRoomValue, code);
        }

        public void Delete()
        {
            Deleted = true;
        }

        private void Validations()
        {
            AssertionHelper.ArgumentNotEmpty(Code, "O código do quarto não pode ser vazio.");
            AssertionHelper.ArgumentLength(Code, 2, "O código do quarto não pode possuir mais que 2 caracteres");
        }
    }
}