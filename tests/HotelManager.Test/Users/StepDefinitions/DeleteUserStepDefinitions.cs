using Microsoft.EntityFrameworkCore;
using HotelManager.Abstraction.Exceptions;
using HotelManager.Core.Exceptions;
using HotelManager.Application.Commands.UserCommands;
using HotelManager.Domain.Entities;
using HotelManager.Test.Infrastructure;

namespace HotelManager.Test.Users.StepDefinitions
{
    [Binding]
    public class DeleteUserStepDefinitions : UserBase
    {
        public DeleteUserStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"I delete the user ""([^""]*)""")]
        public void GivenIDeleteTheUser(string username)
        {
            IdActionUser = Users.First(u => u.Name == username).Id;
        }

        [When(@"I execute the user delete action")]
        public async Task WhenIExecuteTheDeleteAction()
        {
            try
            {
                var command = new DeleteUserCommand()
                {
                    IdUser = IdActionUser,
                    Role = Role
                };

                var mediator = ServicesMock.GetMediator(Context, _scenarioContext, _services);

                await mediator.SendAsync(command);
            }
            catch (UserFriendlyException ex)
            {
                Exception = ex.GetType();
            }
        }

        [Then(@"the users deleted should be")]
        public void ThenTheUsersDeletedShouldBe(Table table)
        {
            var users = Context.Set<User>().IgnoreQueryFilters().ToList();

            foreach (var item in table.Rows)
            {
                var user = users.First(u => u.Id == Users.First(u => u.Name == item["Name"]).Id);

                Assert.Equal(Convert.ToBoolean(item["Deleted"]), user.Deleted);
            }
        }

        [Then(@"I was told it is not possible to delete a admin")]
        public void ThenIWasToldItIsNotPossibleToDeleteAAdmin()
        {
            Assert.Equal(typeof(AdminDeletionException), Exception);
        }


        [Then(@"I was told it is not possible to delete a user")]
        public void ThenIWasToldItIsNotPossibleToDeleteAUser()
        {
            Assert.Equal(typeof(UserDeletionException), Exception);
        }
    }
}