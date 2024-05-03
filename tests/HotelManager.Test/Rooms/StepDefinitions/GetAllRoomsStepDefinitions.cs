using HotelManager.Query.Application.Queries.RoomQueries;
using HotelManager.Test.Infrastructure;

namespace HotelManager.Test.Rooms.StepDefinitions
{
    [Binding]
    public class GetAllRoomsStepDefinitions : RoomBase
    {
        public GetAllRoomsStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext) { }

        [Given(@"all rooms")]
        public void GivenAllRooms()
        {
            Rooms = Rooms;
        }

        [When(@"I perform the action of getting all rooms")]
        public async void WhenIPerformTheActionOfGettingAllRooms()
        {
            var query = new GetAllRoomsQuery();

            var mediator = ServicesMock.GetMediator(QueryContext, _scenarioContext, _services);

            RoomsQuerie = await mediator.SendAsync(query);
        }

        [Then(@"the rooms listed must be")]
        public void ThenTheRoomsListedMustBe(Table table)
        {
            foreach (var item in table.Rows)
            {
                var room = RoomsQuerie.First(r => r.Id == Rooms.First(r => r.Code == item["Code"]).Id);

                Assert.Equal(Convert.ToInt32(item["ActiveReservations"]), room.ReservationsCount);
            }
        }
    }
}