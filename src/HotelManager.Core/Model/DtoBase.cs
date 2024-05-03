using HotelManager.Abstraction.Model;

namespace HotelManager.Core.Model
{
    public abstract class DtoBase : Identifiable
    {
        protected DtoBase(Guid id) : base(id) { }

        protected DtoBase() { }
    }
}