using Microsoft.EntityFrameworkCore;
using HotelManager.Application.Commands.UserCommands;
using HotelManager.Domain.Entities;
using HotelManager.Test.Infrastructure;

namespace HotelManager.Test.Users.StepDefinitions
{
    [Binding]
    public class BlockUserStepDefinitions : UserBase
    {
        public BlockUserStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"my user is registered as ""([^""]*)""")]
        public void GivenMyUserIsRegisteredAs(string username)
        {
            IdUser = Users.First(u => u.Name == username).Id;
            Role = Users.First(u => u.Name == username).Role;
        }

        [Given(@"I block the user ""([^""]*)""")]
        public void GivenIBlockTheUser(string username)
        {
            IdActionUser = Users.First(u=> u.Name == username).Id;
        }

        [When(@"I execute the block action")]
        public async Task WhenIExecuteTheBlockAction()
        {
            var command = new BlockUserCommand()
            {
                IdUser = IdActionUser
            };

            var mediator = ServicesMock.GetMediator(Context, _scenarioContext, _services);

            await mediator.SendAsync(command);
        }

        [Then(@"the users should be")]
        public void ThenTheUsersShouldBe(Table table)
        {
            var users = Context.Set<User>().IgnoreQueryFilters().ToList();

            foreach (var item in table.Rows)
            {
                var user = users.First(u => u.Id == Users.First(u => u.Name == item["Name"]).Id);

                Assert.Equal(Convert.ToBoolean(item["Blocked"]), user.Blocked);
            }
        }
    }
}