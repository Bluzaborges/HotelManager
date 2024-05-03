using HotelManager.Core.Domain;
using HotelManager.Core.Exceptions;
using HotelManager.Core.Enums;

namespace HotelManager.Domain.Entities
{
    public class RoomValue : Entity
    {
        public RoomType Type { get; private set; }
        public string? Name { get; private set; }
        public double Value { get; private set; }

        protected RoomValue() { }

        public void Update(string? name, double value)
        {
            Name = name;
            Value = value;

            Validations();
        }

        private void Validations()
        {
            AssertionHelper.ArgumentLength(Name, 50, "O nome do valor não pode possuir mais que 50 caracteres.");
            AssertionHelper.ArgumentLessThanOrEqual(Value, 0, "O valor não pode ser menor ou igual a zero.");
        }
    }
}