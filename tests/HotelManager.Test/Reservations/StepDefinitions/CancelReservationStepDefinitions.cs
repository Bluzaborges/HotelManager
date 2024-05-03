using Microsoft.EntityFrameworkCore;
using HotelManager.Application.Commands.ReservationCommands;
using HotelManager.Domain.Entities;
using HotelManager.Test.Infrastructure;

namespace HotelManager.Test.Reservations.StepDefinitions
{
    [Binding]
    public class CancelReservationStepDefinitions : ReservationBase
    {
        public CancelReservationStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"I cancel the reservation number (.*)")]
        public void GivenICancelTheReservationNumber(int number)
        {
            IdReservation = Reservations.First(res => res.Sequence == number).Id;
        }

        [When(@"I execute the cancelation")]
        public async Task WhenIExecuteTheCancelation()
        {
            var command = new CancelReservationCommand()
            {
                IdUser = IdUser,
                IdReservation = IdReservation
            };

            var mediator = ServicesMock.GetMediator(Context, _scenarioContext, _services);

            await mediator.SendAsync(command);
        }

        [Then(@"the reservations should be")]
        public void ThenTheResultShouldBe(Table table)
        {
            var reservations = Context.Set<Reservation>().IgnoreQueryFilters().ToList();

            foreach (var item in table.Rows)
            {
                var reservation = reservations.First(res => res.Id == Reservations.First(res => res.Sequence == Convert.ToInt32(item["Reservation"])).Id);

                Assert.Equal(Convert.ToBoolean(item["Deleted"]), reservation.Deleted);
            }
        }

        [Then(@"I am fined (.*)% of the reservation value")]
        public void ThenIAmFinedOfTheReservationValue(double percentage)
        {
            var value = Context.Set<Reservation>().IgnoreQueryFilters()
                                                   .ToList()
                                                   .First(res => res.Id == IdReservation)
                                                   .Value;

            var user = Context.Set<User>().IgnoreQueryFilters().First(u => u.Name == "John");

            var fine = value * (percentage / 100);

            Assert.Equal(fine, user.Fine);
        }
    }
}