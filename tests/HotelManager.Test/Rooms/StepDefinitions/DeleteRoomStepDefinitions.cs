using Microsoft.EntityFrameworkCore;
using HotelManager.Abstraction.Exceptions;
using HotelManager.Core.Exceptions;
using HotelManager.Application.Commands.RoomCommands;
using HotelManager.Domain.Entities;
using HotelManager.Test.Infrastructure;

namespace HotelManager.Test.Rooms.StepDefinitions
{
    [Binding]
    public class DeleteRoomStepDefinitions : RoomBase
    {
        public DeleteRoomStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"I delete the room ""([^""]*)""")]
        public void GivenIDeleteTheRoom(string code)
        {
            IdRoom = Rooms.First(r => r.Code == code).Id;
        }

        [When(@"I execute the room delete action")]
        public async Task WhenIExecuteTheRoomDeleteAction()
        {
            try
            {
                var command = new DeleteRoomCommand()
                {
                    IdRoom = IdRoom
                };

                var mediator = ServicesMock.GetMediator(Context, _scenarioContext, _services);

                await mediator.SendAsync(command);
            }
            catch (UserFriendlyException ex)
            {
                Exception = ex.GetType();
            }
        }

        [Then(@"the rooms deleted should be")]
        public void ThenTheRoomsDeletedShouldBe(Table table)
        {
            var rooms = Context.Set<Room>().IgnoreQueryFilters().ToList();

            foreach (var item in table.Rows)
            {
                var room = rooms.First(r => r.Id == Rooms.First(r => r.Code == item["Code"]).Id);

                Assert.Equal(Convert.ToBoolean(item["Deleted"]), room.Deleted);
            }
        }

        [Then(@"I was told there are active reservations for this room")]
        public void ThenIWasToldThereAreActiveReservationsForThisRoom()
        {
            Assert.Equal(typeof(ActiveReservationsExistException), Exception);
        }
    }
}