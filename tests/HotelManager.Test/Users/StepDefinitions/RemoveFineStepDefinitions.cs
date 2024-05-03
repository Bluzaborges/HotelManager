using Microsoft.EntityFrameworkCore;
using HotelManager.Application.Commands.UserCommands;
using HotelManager.Domain.Entities;
using HotelManager.Test.Infrastructure;

namespace HotelManager.Test.Users.StepDefinitions
{
    [Binding]
    public class RemoveFineStepDefinitions : UserBase
    {
        public RemoveFineStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"I remove the fine from ""([^""]*)""")]
        public void GivenIRemoveTheFineFrom(string username)
        {
            IdActionUser = Users.First(u => u.Name == username).Id;
        }

        [When(@"I execute the remove fine action")]
        public async Task WhenIExecuteTheRemoveFineAction()
        {
            var command = new RemoveFineCommand()
            {
                IdUser = IdActionUser
            };

            var mediator = ServicesMock.GetMediator(Context, _scenarioContext, _services);

            await mediator.SendAsync(command);
        }

        [Then(@"the users fine should be")]
        public void ThenTheUsersFineShouldBe(Table table)
        {
            var users = Context.Set<User>().IgnoreQueryFilters().ToList();

            foreach (var item in table.Rows)
            {
                var user = users.First(u => u.Id == Users.First(u => u.Name == item["Name"]).Id);

                Assert.Equal(Convert.ToDouble(item["Fine"]), user.Fine);
            }
        }
    }
}