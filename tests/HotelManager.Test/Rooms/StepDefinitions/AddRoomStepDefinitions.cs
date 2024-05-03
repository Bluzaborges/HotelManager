using HotelManager.Abstraction.Exceptions;
using HotelManager.Core.Exceptions;
using HotelManager.Core.Enums;
using HotelManager.Application.Commands.RoomCommands;
using HotelManager.Test.Infrastructure;
using HotelManager.Test.Models;

namespace HotelManager.Test.Rooms.StepDefinitions
{
    [Binding]
    public class AddRoomStepDefinitions : RoomBase
    {
        public AddRoomStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"the code is ""([^""]*)"" and the type is ""([^""]*)""")]
        public void GivenTheCodeIsAndTheTypeIs(string code, RoomType type)
        {
            Room = RoomTest.Create(code, type);
        }

        [When(@"I add the room")]
        public async Task WhenIAddTheRoom()
        {
            try
            {
                var command = new AddRoomCommand()
                {
                    Code = Room.Code,
                    Type = Room.Type
                };

                var mediator = ServicesMock.GetMediator(Context, _scenarioContext, _services);

                await mediator.SendAsync(command);
            }
            catch (UserFriendlyException ex)
            {
                Exception = ex.GetType();
            }
        }

        [Then(@"I'm told there are rooms registered with the code")]
        public void ThenImToldThereAreRoomsRegisteredWithTheCode()
        {
            Assert.Equal(typeof(RoomCodeAlreadyExistsException), Exception);
        }
    }
}