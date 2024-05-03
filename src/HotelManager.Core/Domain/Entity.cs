using HotelManager.Abstraction.Model;

namespace HotelManager.Core.Domain
{
    public abstract class Entity : Identifiable
    {
        protected Entity(Guid id) : base(id) { }

        protected Entity() { }
    }
}