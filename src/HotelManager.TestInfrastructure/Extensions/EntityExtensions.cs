using System.Reflection;
using System.Linq.Expressions;
using HotelManager.Abstraction.Model;

namespace HotelManager.TestInfrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void SetProperty<TEntity>(this Identifiable source, Expression<Func<TEntity, object>> property, object value) where TEntity : class
        {
            string propertyName = "";

            if (property.Body is UnaryExpression expression)
            {
                propertyName = ((MemberExpression)expression.Operand).Member.Name;
            }
            else
            {
                propertyName = ((MemberExpression)property.Body).Member.Name;
            }

            var searchProperty = (from p in source.GetType().GetTypeInfo().GetProperties() where p.Name.Equals(propertyName) select p).FirstOrDefault();

            if (searchProperty != null )
            {
                searchProperty.SetValue(source, value);
            } 
            else
            {
                throw new Exception($"A propriedade {propertyName} não foi encontrada na entidade {typeof(Identifiable).Name}.");
            }
        }
    }
}