
using HotelManager.Query.Application.Queries.RoomValueQueries;
using HotelManager.Test.Infrastructure;

namespace HotelManager.Test.RoomValues.StepDefinitions
{
    [Binding]
    public class GetAllRoomValuesStepDefinitions : RoomValueBase
    {
        public GetAllRoomValuesStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"all room values")]
        public void GivenAllRoomValues()
        {
            RoomValues = RoomValues;
        }

        [When(@"I perform the action of getting all room values")]
        public async void WhenIPerformTheActionOfGettingAllRoomValues()
        {
            var query = new GetAllRoomValuesQuery();

            var mediator = ServicesMock.GetMediator(QueryContext, _scenarioContext, _services);

            RoomValuesQuerie = await mediator.SendAsync(query);
        }

        [Then(@"the rooms values listed must be")]
        public void ThenTheRoomsValuesListedMustBe(Table table)
        {
            foreach (var item in table.Rows)
            {
                var roomValue = RoomValuesQuerie.First(r => r.Id == RoomValues.First(r => r.Number == Convert.ToInt32(item["Number"])).Id);

                Assert.Equal(Convert.ToInt32(item["RoomsCount"]), roomValue.RoomsCount);
            }
        }
    }
}