using HotelManager.Abstraction.Exceptions;
using HotelManager.Application.Commands.ReservationCommands;
using HotelManager.Test.Infrastructure;

namespace HotelManager.Test.Reservations.StepDefinitions
{
    [Binding]
    public class UpdateReservationStepDefinitions : ReservationBase
    {
        public UpdateReservationStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"I update the reservation (.*)")]
        public void GivenIUpdateTheReservation(int sequence)
        {
            IdReservation = Reservations.First(res => res.Sequence == sequence).Id;
        }

        [When(@"I update the reserbation")]
        public async Task WhenIUpdateTheReserbation()
        {
            try
            {
                var command = new UpdateReservationCommand()
                {
                    IdUser = IdUser,
                    IdReservation = IdReservation,
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
    }
}