using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Application.Commands.RoomValueCommands;
using HotelManager.Query.Application.Queries.RoomValueQueries;

namespace HotelManager.Api.Controllers
{
    [Route("RoomValue")]
    public class RoomValueController : Controller
    {
        private readonly IMediatorHandler _mediatorHandler;

        public RoomValueController (IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [Authorize]
        [HttpGet("")]
        public async Task<IActionResult> GetAllRoomValues()
        {
            return Ok(await _mediatorHandler.SendAsync(new GetAllRoomValuesQuery()));
        }

        [Authorize("Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomValueAsync(Guid id)
        {
            return Ok(await _mediatorHandler.SendAsync(new GetRoomValueByIdQuery() { IdRoomValue = id }));
        }

        [Authorize("Admin")]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateRoomValue([FromBody] UpdateRoomValueCommand command)
        {
            await _mediatorHandler.SendAsync(command);

            return Ok(new { message = "Valor atualizado com sucesso." });
        }
    }
}