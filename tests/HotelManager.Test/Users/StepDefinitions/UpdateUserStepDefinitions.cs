using HotelManager.Abstraction.Exceptions;
using HotelManager.Application.Commands.UserCommands;
using HotelManager.Test.Infrastructure;

namespace HotelManager.Test.Users.StepDefinitions
{
    [Binding]
    public class UpdateUserStepDefinitions : UserBase
    {
        public UpdateUserStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"I update my email to ""([^""]*)""")]
        public void GivenIUpdateMyEmailTo(string email)
        {
            User = Users.First(u => u.Id == IdUser);

            User.Email = email;
        }

        [Given(@"I update my cpf to ""([^""]*)""")]
        public void GivenIUpdateMyCpfTo(string cpf)
        {
            User = Users.First(u => u.Id == IdUser);

            User.Cpf = cpf;
        }

        [When(@"I update my user")]
        public async Task WhenIUpdateMyUser()
        {
            try
            {
                var command = new UpdateUserCommand()
                {
                    IdUser = IdUser,
                    Name = User.Name,
                    Email = User.Email,
                    Cpf = User.Cpf,
                    Phone = User.Phone
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