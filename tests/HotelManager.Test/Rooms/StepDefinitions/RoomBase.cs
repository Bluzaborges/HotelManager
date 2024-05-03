using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using HotelManager.Data.Contexts;
using HotelManager.Query.Data.Contexts;
using HotelManager.Query.Application.ViewModels;
using HotelManager.Test.Models;

namespace HotelManager.Test.Rooms.StepDefinitions
{
    public class RoomBase
    {
        protected readonly ScenarioContext _scenarioContext;
        protected readonly ServiceCollection _services;

        public RoomBase(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;

            _services = new ServiceCollection();
        }

        internal SqliteConnection Connection
        {
            get { return _scenarioContext.Get<SqliteConnection>(nameof(Connection)); }
            set { _scenarioContext.Set(value, nameof(Connection)); }
        }

        internal ServiceProvider ServiceProvider
        {
            get { return _scenarioContext.Get<ServiceProvider>(nameof(ServiceProvider)); }
            set { _scenarioContext.Set(value, nameof(ServiceProvider)); }
        }

        internal BookingDbContext Context
        {
            get { return ServiceProvider.GetService<BookingDbContext>() ?? throw new InvalidOperationException("BookingDbContext não pode ser nulo."); }
        }

        internal HotelManagerQueryDbContext QueryContext
        {
            get { return ServiceProvider.GetService<HotelManagerQueryDbContext>() ?? throw new InvalidOperationException("HotelManagerQueryDbContext não pode ser nulo."); }
        }

        internal Type Exception
        {
            get { _scenarioContext.TryGetValue(nameof(Exception), out Type value); return value; }
            set { _scenarioContext.Set(value, nameof(Exception)); }
        }

        internal IEnumerable<RoomTest> Rooms
        {
            get { _scenarioContext.TryGetValue(nameof(Rooms), out IEnumerable<RoomTest> value); return value ?? new List<RoomTest>(); }
            set { _scenarioContext.Set(value, nameof(Rooms)); }
        }

        internal RoomTest Room
        {
            get { _scenarioContext.TryGetValue(nameof(Room), out RoomTest value); return value; }
            set { _scenarioContext.Set(value, nameof(Room)); }
        }

        internal IEnumerable<RoomViewModel> RoomsQuerie
        {
            get { _scenarioContext.TryGetValue(nameof(RoomsQuerie), out IEnumerable<RoomViewModel> value); return value ?? new List<RoomViewModel>(); }
            set { _scenarioContext.Set(value, nameof(RoomsQuerie)); }
        }

        internal Guid IdRoom
        {
            get { _scenarioContext.TryGetValue(nameof(IdRoom), out Guid value); return value; }
            set { _scenarioContext.Set(value, nameof(IdRoom)); }
        }
    }
}