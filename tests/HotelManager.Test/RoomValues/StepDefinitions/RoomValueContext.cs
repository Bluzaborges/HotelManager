using Microsoft.Extensions.DependencyInjection;
using HotelManager.TestInfrastructure.Helpers;
using HotelManager.Data.Contexts;
using HotelManager.Query.Data.Contexts;

namespace HotelManager.Test.RoomValues.StepDefinitions
{
    public class RoomValueContext : RoomValueBase
    {
        public RoomValueContext(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            Connection = EntityTestHelper.GenerateNewConnection();

            var context = EntityTestHelper.GetDbContext<BookingDbContext>(Connection);
            context.Database.EnsureCreated();

            var queryContext = EntityTestHelper.GetDbContext<HotelManagerQueryDbContext>(Connection);
            queryContext.Database.EnsureCreated();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddScoped((a) => context);
            serviceCollection.AddScoped((a) => queryContext);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}