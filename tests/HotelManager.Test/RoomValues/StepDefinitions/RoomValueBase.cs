using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using HotelManager.Data.Contexts;
using HotelManager.Query.Application.ViewModels;
using HotelManager.Query.Data.Contexts;
using HotelManager.Test.Models;

namespace HotelManager.Test.RoomValues.StepDefinitions
{
    public class RoomValueBase
    {
        protected readonly ScenarioContext _scenarioContext;
        protected readonly ServiceCollection _services;

        public RoomValueBase(ScenarioContext scenarioContext)
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

        internal IEnumerable<RoomValueTest> RoomValues
        {
            get { _scenarioContext.TryGetValue(nameof(RoomValues), out IEnumerable<RoomValueTest> value); return value ?? new List<RoomValueTest>(); }
            set { _scenarioContext.Set(value, nameof(RoomValues)); }
        }

        internal IEnumerable<RoomValueViewModel> RoomValuesQuerie
        {
            get { _scenarioContext.TryGetValue(nameof(RoomValuesQuerie), out IEnumerable<RoomValueViewModel> value); return value ?? new List<RoomValueViewModel>(); }
            set { _scenarioContext.Set(value, nameof(RoomValuesQuerie)); }
        }

        internal Guid IdRoomValue
        {
            get { _scenarioContext.TryGetValue(nameof(Guid), out Guid value); return value; }
            set { _scenarioContext.Set(value, nameof(Guid)); }
        }

        internal double Value
        {
            get { _scenarioContext.TryGetValue(nameof(Value), out double value); return value; }
            set { _scenarioContext.Set(value, nameof(Value)); }
        }

        internal string Name
        {
            get { _scenarioContext.TryGetValue(nameof(Name), out string value); return value; }
            set { _scenarioContext.Set(value, nameof(Name)); }
        }
    }
}