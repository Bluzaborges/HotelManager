using Microsoft.EntityFrameworkCore;
using HotelManager.Core.Enums;
using HotelManager.Application.Commands.RoomValueCommands;
using HotelManager.Domain.Entities;
using HotelManager.Test.Infrastructure;

namespace HotelManager.Test.RoomValues.StepDefinitions
{
    [Binding]
    public class UpdateRoomValueStepDefinitions : RoomValueBase
    {
        public UpdateRoomValueStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"I update the value of the ""([^""]*)"" room value to (.*)")]
        public void GivenIUpdateTheValueOfTheRoomValueTo(RoomType type, double value)
        {
            IdRoomValue = RoomValues.First(v => v.Type == type).Id;
            Value = value;
        }

        [Given(@"the name to ""([^""]*)""")]
        public void GivenTheNameTo(string name)
        {
            Name = name;
        }

        [When(@"I update the room value")]
        public async void WhenIUpdateTheRoomValue()
        {
            var command = new UpdateRoomValueCommand()
            {
                IdRoomValue = IdRoomValue,
                Name = Name,
                Value = Value
            };

            var mediator = ServicesMock.GetMediator(Context, _scenarioContext, _services);

            await mediator.SendAsync(command);
        }

        [Then(@"the room values should be")]
        public void ThenTheRoomValuesShouldBe(Table table)
        {
            var roomValues = Context.Set<RoomValue>().IgnoreQueryFilters().ToList();

            foreach (var item in table.Rows)
            {
                var roomValue = roomValues.First(res => res.Id == RoomValues.First(v => v.Number == Convert.ToInt32(item["Number"])).Id);

                Assert.Equal(Convert.ToDouble(item["Value"]), roomValue.Value);
            }
        }
    }
}