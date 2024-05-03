using HotelManager.Application.Commands.UserCommands;
using HotelManager.Test.Infrastructure;

namespace HotelManager.Test.Users.StepDefinitions
{
    [Binding]
    public class UnblockUserStepDefinitions : UserBase
    {
        public UnblockUserStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"I unblock the user ""([^""]*)""")]
        public void GivenIUnblockTheUser(string username)
        {
            IdActionUser = Users.First(u => u.Name == username).Id;
        }

        [When(@"I execute the unblock action")]
        public async Task WhenIExecuteTheUnblockAction()
        {
            var command = new UnblockUserCommand()
            {
                IdUser = IdActionUser
            };

            var mediator = ServicesMock.GetMediator(Context, _scenarioContext, _services);

            await mediator.SendAsync(command);
        }
    }
}