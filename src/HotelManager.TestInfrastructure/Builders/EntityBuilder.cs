using System.Linq.Expressions;
using HotelManager.Abstraction.Model;
using HotelManager.TestInfrastructure.Extensions;

namespace HotelManager.TestInfrastructure.Builders
{
    public class EntityBuilder<TEntity> where TEntity : Identifiable
    {
        private readonly TEntity _entity;

        public EntityBuilder()
        {
            _entity = (TEntity?)Activator.CreateInstance(typeof(TEntity), nonPublic: true) ?? throw new Exception("Não foi possível criar uma instância de TEntity.");
        }

        public EntityBuilder(TEntity entity)
        {
            _entity = entity;
        }

        public EntityBuilder<TEntity> SetValue(Expression<Func<TEntity, object>> property, object value)
        {
            _entity.SetProperty(property, value);

            return this;
        }

        public TEntity Build(Action<EntityBuilder<TEntity>> action)
        {
            action(this);
            return _entity;
        }

        public TEntity Build()
        {
            return _entity;
        }
    }
}