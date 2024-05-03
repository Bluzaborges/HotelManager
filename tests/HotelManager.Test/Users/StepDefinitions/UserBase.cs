using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Sqlite;
using HotelManager.Core.Enums;
using HotelManager.Data.Contexts;
using HotelManager.Test.Models;

namespace HotelManager.Test.Users.StepDefinitions
{
    public class UserBase
    {
        protected readonly ScenarioContext _scenarioContext;
        protected readonly ServiceCollection _services;

        public UserBase(ScenarioContext scenarioContext)
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

        internal IEnumerable<UserTest> Users
        {
            get { _scenarioContext.TryGetValue(nameof(Users), out IEnumerable<UserTest> value); return value ?? new List<UserTest>(); }
            set { _scenarioContext.Set(value, nameof(Users)); }
        }

        internal UserTest User
        {
            get { _scenarioContext.TryGetValue(nameof(User), out UserTest value); return value; }
            set { _scenarioContext.Set(value, nameof(User)); }
        }

        internal Guid IdActionUser
        {
            get { _scenarioContext.TryGetValue(nameof(IdActionUser), out Guid value); return value; }
            set { _scenarioContext.Set(value, nameof(IdActionUser)); }
        }

        internal Guid IdUser
        {
            get { _scenarioContext.TryGetValue(nameof(IdUser), out Guid value); return value; }
            set { _scenarioContext.Set(value, nameof(IdUser)); }
        }

        internal UserRole Role
        {
            get { _scenarioContext.TryGetValue(nameof(Role), out UserRole value); return value; }
            set { _scenarioContext.Set(value, nameof(Role)); }
        }

        internal string Email
        {
            get { _scenarioContext.TryGetValue(nameof(Email), out string value); return value; }
            set { _scenarioContext.Set(value, nameof(Email)); }
        }

        internal string Cpf
        {
            get { _scenarioContext.TryGetValue(nameof(Cpf), out string value); return value; }
            set { _scenarioContext.Set(value, nameof(Cpf)); }
        }
    }
}