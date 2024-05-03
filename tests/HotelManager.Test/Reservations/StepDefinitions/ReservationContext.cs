using Microsoft.Extensions.DependencyInjection;
using HotelManager.TestInfrastructure.Builders;
using HotelManager.TestInfrastructure.Helpers;
using HotelManager.Core.Enums;
using HotelManager.Data.Contexts;
using HotelManager.Domain.Entities;
using HotelManager.Query.Data.Contexts;
using HotelManager.Test.Models;

namespace HotelManager.Test.Reservations.StepDefinitions
{
    [Binding]
    public class ReservationContext : ReservationBase
    {
        public ReservationContext(ScenarioContext scenarioContext) : base(scenarioContext)
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

        [Given(@"these room values")]
        public void GivenTheseRoomValues(Table table)
        {
            List<RoomValueTest> roomValues = new List<RoomValueTest>();

            foreach (var item in table.Rows)
            {
                var roomValue = RoomValueTest.Create(Convert.ToInt32(item["Number"]),
                                                     Enum.TryParse(item["Type"], out RoomType type) ? type : throw new Exception("Tipo não identificado."),
                                                     item["Name"],
                                                     Convert.ToDouble(item["Value"]));

                Context.Add(new EntityBuilder<RoomValue>().Build(b =>
                {
                    b.SetValue(v => v.Id, roomValue.Id);
                    b.SetValue(v => v.Type, roomValue.Type);
                    b.SetValue(v => v.Name, roomValue.Name);
                    b.SetValue(v => v.Value, roomValue.Value);
                }));

                roomValues.Add(roomValue);
            }

            Context.SaveChanges();

            RoomValues = roomValues;
        }

        [Given(@"these rooms")]
        public void GivenTheseRooms(Table table)
        {
            List<RoomTest> rooms = new List<RoomTest>();

            foreach (var item in table.Rows)
            {
                var roomValue = RoomValues.First(v => v.Number == Convert.ToInt32(item["RoomValue"]));

                var room = RoomTest.Create(item["Code"], roomValue);

                Context.Add(new EntityBuilder<Room>().Build(b =>
                {
                    b.SetValue(r => r.Id, room.Id);
                    b.SetValue(r => r.IdRoomValue, room.RoomValue.Id);
                    b.SetValue(r => r.Code, room.Code);
                    b.SetValue(r => r.Deleted, Convert.ToBoolean(item["Deleted"]));
                }));
                
                rooms.Add(room);
            }

            Context.SaveChanges();

            Rooms = rooms;
        }

        [Given(@"these registered users")]
        public void GivenTheseRegisteredUsers(Table table)
        {
            List<UserTest> users = new List<UserTest>();

            foreach (var item in table.Rows)
            {
                var user = UserTest.Create(item["Name"], 
                                           item["Email"],
                                           item["Password"],
                                           Enum.TryParse(item["Role"], out UserRole type) ? type : throw new Exception("Tipo não identificado."),
                                           item["Cpf"],
                                           item["Phone"]);

                Context.Add(new EntityBuilder<User>().Build(b =>
                {
                    b.SetValue(u => u.Id, user.Id);
                    b.SetValue(u => u.Name, user.Name);
                    b.SetValue(u => u.Email, user.Email);
                    b.SetValue(u => u.Password, user.Password);
                    b.SetValue(u => u.Role, user.Role);
                    b.SetValue(u => u.Cpf, user.Cpf);
                    b.SetValue(u => u.Phone, user.Phone);
                    b.SetValue(u => u.Fine, Convert.ToDouble(item["Fine"]));
                    b.SetValue(u => u.Blocked, Convert.ToBoolean(item["Blocked"]));
                }));

                users.Add(user);
            }

            Context.SaveChanges();

            Users = users;
        }

        [Given(@"all reservations start in (.*) hours from now")]
        public void GivenAllReservationsStartInHoursFromNow(int hours)
        {
            StartDate = DateTime.Now.AddHours(hours);
        }

        [Given(@"all reservations ends after (.*) days from start")]
        public void GivenAllReservationsEndsAfterDaysFromStart(int days)
        {
            EndDate = StartDate.AddDays(days);
        }


        [Given(@"these reservations")]
        public void GivenTheseReservations(Table table)
        {
            List<ReservationTest> reservations = new List<ReservationTest>();

            foreach (var item in table.Rows)
            {
                var reservation = ReservationTest.Create(Convert.ToInt32(item["Reservation"]));

                Context.Add(new EntityBuilder<Reservation>().Build(b =>
                {
                    b.SetValue(res => res.Id, reservation.Id);
                    b.SetValue(res => res.IdUser, Users.First(u => u.Name == item["User"]).Id);
                    b.SetValue(res => res.IdRoom, Rooms.First(r => r.Code == item["Room"]).Id);
                    b.SetValue(res => res.Value, Rooms.First(r => r.Code == item["Room"]).RoomValue.Value * (EndDate - StartDate).TotalDays);
                    b.SetValue(res => res.StartDate, StartDate);
                    b.SetValue(res => res.EndDate, EndDate);
                    b.SetValue(res => res.Deleted, Convert.ToBoolean(item["Deleted"]));
                }));

                reservations.Add(reservation);
            }

            Context.SaveChanges();

            Reservations = reservations;
        }
    }
}