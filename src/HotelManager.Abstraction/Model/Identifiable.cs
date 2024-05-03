using HotelManager.Abstraction.Model.Abstractions;

namespace HotelManager.Abstraction.Model
{
    public abstract class Identifiable : IIdentifiable
    {
        public Guid Id { get; set; }

        protected Identifiable(Guid id)
        {
            Id = id;
        }

        protected Identifiable() { }
    }
}