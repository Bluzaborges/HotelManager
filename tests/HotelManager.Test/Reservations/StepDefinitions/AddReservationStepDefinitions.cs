using System.Globalization;
using Microsoft.EntityFrameworkCore;
using HotelManager.Abstraction.Exceptions;
using HotelManager.Core.Exceptions;
using HotelManager.Core.Enums;
using HotelManager.Application.Commands.ReservationCommands;
using HotelManager.Domain.Entities;
using HotelManager.Test.Infrastructure;

namespace HotelManager.Test.Reservations.StepDefinitions
{
    [Binding]
    public class AddReservationStepDefinitions : ReservationBase
    {
        public AddReservationStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"I reserve a ""([^""]*)"" room in (.*) days")]
        public void GivenIReserveARoomInDays(RoomType type, int days)
        {
            StartDate = DateTime.Now.AddDays(days);
            RoomType = type;
        }

        [Given(@"with a duration of (.*) days")]
        public void GivenWithADurationOfDays(int days)
        {
            EndDate = StartDate.AddDays(days);
        }

        [When(@"I add the reservation")]
        public async Task WhenIAddTheReservation()
        {
            try
            {
                var command = new AddReservationCommand()
                {
                    IdUser = IdUser,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Type = RoomType
                };

                var mediator = ServicesMock.GetMediator(Context, _scenarioContext, _services);

                await mediator.SendAsync(command);
            }
            catch (UserFriendlyException ex)
            {
                Exception = ex.GetType();
            }
        }

        [Then(@"I'm told there are no rooms available")]
        public void ThenImToldThereAreNoRoomsAvailable()
        {
            Assert.Equal(typeof(NotDisponibleRoomException), Exception);
        }

        [Then(@"I'm told there are not possible to reserve a room")]
        public void ThenImToldThereAreNotPossibleToReserveARoom()
        {
            Assert.Equal(typeof(UserFriendlyException), Exception);
        }

        [Then(@"the end and start time should be (.*)")]
        public void ThenTheEndAndStartTimeShouldBe(string time)
        {
            var reservation = Context.Set<Reservation>().IgnoreQueryFilters()
                                                        .ToList()
                                                        .First(res => res.IdUser == IdUser);

            DateTime expectedTime = DateTime.ParseExact(time, "HH:mm", CultureInfo.InvariantCulture);

            Assert.Equal(expectedTime.Hour, reservation.StartDate.Hour);
            Assert.Equal(expectedTime.Hour, reservation.EndDate.Hour);
        }

        [Then(@"the duration must be (.*) days")]
        public void ThenTheDurationMustBeDays(int days)
        {
            var reservation = Context.Set<Reservation>().IgnoreQueryFilters()
                                                        .ToList()
                                                        .First(res => res.IdUser == IdUser);

            Assert.Equal(days, (reservation.EndDate - reservation.StartDate).TotalDays);
        }

        [Then(@"the room must be of the ""([^""]*)"" type")]
        public void ThenTheRoomMustBeOfTheType(RoomType type)
        {
            var reservation = Context.Set<Reservation>().IgnoreQueryFilters().ToList().First(res => res.IdUser == IdUser);

            Assert.NotNull(reservation.Room);
            Assert.NotNull(reservation.Room?.RoomValue);

            Assert.Equal(type, reservation.Room?.RoomValue?.Type);
        }

        [Then(@"the value must be calculated correctly")]
        public void ThenTheValueMustBeCalculatedCorrectly()
        {
            var reservation = Context.Set<Reservation>().IgnoreQueryFilters().ToList().First(res => res.IdUser == IdUser);

            int days = 7;

            Assert.NotNull(reservation.Room);
            Assert.NotNull(reservation.Room?.RoomValue);

            var expectedVaue = RoomValues.First(v => v.Id == reservation.Room?.RoomValue?.Id).Value * days;

            Assert.Equal(reservation.Value, expectedVaue);
        }
    }
}