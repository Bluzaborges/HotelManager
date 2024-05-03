using HotelManager.Core.Exceptions;
using HotelManager.Core.Enums;
using HotelManager.Application.Commands.UserCommands;
using HotelManager.Test.Infrastructure;
using HotelManager.Test.Models;

namespace HotelManager.Test.Users.StepDefinitions
{
    [Binding]
    public class AddUserStepDefinitions : UserBase
    {
        public AddUserStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"my name is ""([^""]*)"", my email is ""([^""]*)"", my password is ""([^""]*)"", my cpf is ""([^""]*)"" and my phone is ""([^""]*)""")]
        public void GivenMyNameIsMyEmailIsMyPasswordIsMyCpfIsAndMyPhoneIs(string name, string email, string password, string cpf, string phone)
        {
            User = UserTest.Create(name, email, password, UserRole.Customer, cpf, phone);
        }

        [When(@"I add my user")]
        public async Task WhenIAddMyUser()
        {
            try
            {
                var command = new AddUserCommand()
                {
                    Name = User.Name,
                    Email = User.Email,
                    Password = User.Password,
                    Cpf = User.Cpf,
                    Phone = User.Phone,
                };

                var mediator = ServicesMock.GetMediator(Context, _scenarioContext, _services);

                await mediator.SendAsync(command);
            }
            catch (UserEmailAlreadyExistsException ex)
            {
                Exception = ex.GetType();
            }
            catch (UserCpfAlreadyExistsException ex)
            {
                Exception = ex.GetType();
            }
        }

        [Then(@"I'm told there are users registered with my email")]
        public void ThenImToldThereAreUsersRegisteredWithMyEmail()
        {
            Assert.Equal(typeof(UserEmailAlreadyExistsException), Exception);
        }

        [Then(@"I'm told there are users registered with my cpf")]
        public void ThenImToldThereAreUsersRegisteredWithMyCpf()
        {
            Assert.Equal(typeof(UserCpfAlreadyExistsException), Exception);
        }
    }
}