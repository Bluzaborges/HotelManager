using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Application.Commands.RoomCommands;
using HotelManager.Query.Application.Queries.RoomQueries;

namespace HotelManager.Api.Controllers
{
    [Route("Room")]
    public class RoomController : Controller
    {
        private readonly IMediatorHandler _mediatorHandler;

        public RoomController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [Authorize("Admin")]
        [HttpGet("")]
        public async Task<IActionResult> GetAllRooms()
        {
            return Ok(await _mediatorHandler.SendAsync(new GetAllRoomsQuery()));
        }

        [Authorize("Admin")]
        [HttpPut("Add")]
        public async Task<IActionResult> AddRoomAsync([FromBody] AddRoomCommand command)
        {
            await _mediatorHandler.SendAsync(command);

            return Ok(new { message = "Quarto adicionado com sucesso." });
        }

        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomAsync(Guid id)
        {
            await _mediatorHandler.SendAsync(new DeleteRoomCommand { IdRoom = id });

            return Ok(new { message = "Quarto excluído com sucesso." });
        }
    }
}