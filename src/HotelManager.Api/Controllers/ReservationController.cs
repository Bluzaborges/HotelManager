using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Abstraction.Identity.Abstractions;
using HotelManager.Application.Services.Abstractions;
using HotelManager.Application.Commands.ReservationCommands;
using HotelManager.Query.Application.Queries.ReservationQueries;

namespace HotelManager.Api.Controllers
{
    [Route("Reservation")]
    public class ReservationController : Controller
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAuthUserData _userData;
        private readonly IReservationAppService _reservationAppService;

        public ReservationController(IMediatorHandler mediatorHandler, IAuthUserData userData, IReservationAppService reservationAppService)
        {
            _mediatorHandler = mediatorHandler;
            _userData = userData;
            _reservationAppService = reservationAppService;
        }

        [Authorize]
        [HttpGet("")]
        public async Task<IActionResult> GetAllReservations()
        {
            return Ok(await _mediatorHandler.SendAsync(new GetAllReservationsQuery() { IdUser = _userData.IdUser }));
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservationAsync(Guid id)
        {
            return Ok(await _mediatorHandler.SendAsync(new GetReservationByIdQuery() { IdReservation = id, IdUser = _userData.IdUser }));
        }

        [Authorize]
        [HttpGet("Fine/{startDate}")]
        public IActionResult CheckFine(DateTime startDate)
        {
            return Ok(_reservationAppService.CheckFine(startDate));
        }

        [Authorize]
        [HttpPut("Add")]
        public async Task<IActionResult> AddReservationAsync([FromBody] AddReservationCommand command)
        {
            command.IdUser = _userData.IdUser;

            await _mediatorHandler.SendAsync(command);

            return Ok(new { message = "Quarto reservado com sucesso." });
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateReservationAsync([FromBody] UpdateReservationCommand command)
        {
            command.IdUser = _userData.IdUser;

            await _mediatorHandler.SendAsync(command);

            return Ok(new { message = "Reserva alterada com sucesso." });
        }

        [Authorize]
        [HttpPatch("Cancel/{id}")]
        public async Task<IActionResult> CancelReservationAsync(Guid id)
        {
            Guid idUser = _userData.IdUser;

            await _mediatorHandler.SendAsync(new CancelReservationCommand() { IdUser = idUser, IdReservation = id });

            return Ok(new { message = "Reserva cancelada com sucesso." });
        }
    }
}