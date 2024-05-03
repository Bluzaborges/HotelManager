using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using HotelManager.Core.Enums;
using HotelManager.Data.Contexts;
using HotelManager.Test.Models;

namespace HotelManager.Test.Reservations.StepDefinitions
{
    public class ReservationBase
    {
        protected readonly ScenarioContext _scenarioContext;
        protected readonly ServiceCollection _services;

        public ReservationBase(ScenarioContext scenarioContext)
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

        internal Type Exception
        {
            get { _scenarioContext.TryGetValue(nameof(Exception), out Type value); return value; }
            set { _scenarioContext.Set(value, nameof(Exception)); }
        }

        internal IEnumerable<ReservationTest> Reservations
        {
            get { _scenarioContext.TryGetValue(nameof(Reservations), out IEnumerable<ReservationTest> value); return value ?? new List<ReservationTest>(); }
            set { _scenarioContext.Set(value, nameof(Reservations)); }
        }

        internal IEnumerable<UserTest> Users
        {
            get { _scenarioContext.TryGetValue(nameof(Users), out IEnumerable<UserTest> value); return value ?? new List<UserTest>(); }
            set { _scenarioContext.Set(value, nameof(Users)); }
        }

        internal IEnumerable<RoomTest> Rooms
        {
            get { _scenarioContext.TryGetValue(nameof(Rooms), out IEnumerable<RoomTest> value); return value ?? new List<RoomTest>(); }
            set { _scenarioContext.Set(value, nameof(Rooms)); }
        }

        internal IEnumerable<RoomValueTest> RoomValues
        {
            get { _scenarioContext.TryGetValue(nameof(RoomValues), out IEnumerable<RoomValueTest> value); return value ?? new List<RoomValueTest>(); }
            set { _scenarioContext.Set(value, nameof(RoomValues)); }
        }

        internal Guid IdReservation
        {
            get { _scenarioContext.TryGetValue(nameof(IdReservation), out Guid value); return value; }
            set { _scenarioContext.Set(value, nameof(IdReservation)); }
        }

        internal Guid IdUser
        {
            get { _scenarioContext.TryGetValue(nameof(IdUser), out Guid value); return value; }
            set { _scenarioContext.Set(value, nameof(IdUser)); }
        }

        internal RoomType RoomType
        {
            get { _scenarioContext.TryGetValue(nameof(RoomType), out RoomType value); return value; }
            set { _scenarioContext.Set(value, nameof(RoomType)); }
        }

        internal DateTime StartDate
        {
            get { _scenarioContext.TryGetValue(nameof(StartDate), out DateTime value); return value; }
            set { _scenarioContext.Set(value, nameof(StartDate)); }
        }

        internal DateTime EndDate
        {
            get { _scenarioContext.TryGetValue(nameof(EndDate), out DateTime value); return value; }
            set { _scenarioContext.Set(value, nameof(EndDate)); }
        } 
    }
}