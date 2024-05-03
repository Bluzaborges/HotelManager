using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HotelManager.Abstraction.Mediator.Abstractions;
using HotelManager.Abstraction.Identity.Abstractions;
using HotelManager.Core.Enums;
using HotelManager.Application.Commands.UserCommands;
using HotelManager.Query.Application.Queries.UserQueries;

namespace HotelManager.Api.Controllers
{
    [Route("User")]
    public class UserController : Controller
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IAuthUserData _userData;

        public UserController(IMediatorHandler mediatorHandler, IAuthUserData userData)
        {
            _mediatorHandler = mediatorHandler;
            _userData = userData;
        }

        [Authorize]
        [HttpGet("")]
        public async Task<IActionResult> GetUserAsync()
        {
            return Ok(await _mediatorHandler.SendAsync(new GetUserByIdQuery() { IdUser = _userData.IdUser }));
        }

        [Authorize("AdminOrAttendant")]
        [HttpGet("Customers")]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            return Ok(await _mediatorHandler.SendAsync(new GetAllCustomersQuery()));
        }

        [Authorize("Admin")]
        [HttpGet("Employees")]
        public async Task<IActionResult> GetAllEmployeesAsync()
        {
            return Ok(await _mediatorHandler.SendAsync(new GetAllEmployeesQuery() { IdUser = _userData.IdUser }));
        }

        [Authorize]
        [HttpGet("Fine")]
        public async Task<IActionResult> GetFineAsync()
        {
            return Ok(await _mediatorHandler.SendAsync(new GetFineQuery() { IdUser = _userData.IdUser }));
        }

        [HttpPost("Signin")]
        public async Task<IActionResult> SignInAsync([FromBody] SignInCommand command)
        {
            return Ok(new { token = await _mediatorHandler.SendAsync(command) });
        }

        [HttpPut("Add")]
        public async Task<IActionResult> AddUserAsync([FromBody] AddUserCommand command)
        {
            await _mediatorHandler.SendAsync(command);

            return Ok(new { message = "Conta criada com sucesso." });
        }

        [Authorize]
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserCommand command)
        {
            command.IdUser = _userData.IdUser;

            await _mediatorHandler.SendAsync(command);

            return Ok(new { message = "Informações atualizadas com sucesso." });
        }

        [Authorize]
        [HttpPatch("Password")]
        public async Task<IActionResult> UpdatePasswordAsync([FromBody] UpdatePasswordCommand command)
        {
            command.IdUser = _userData.IdUser;

            await _mediatorHandler.SendAsync(command);

            return Ok(new { message = "Senha atualizada com sucesso." });
        }

        [Authorize("AdminOrAttendant")]
        [HttpPatch("Block/{id}")]
        public async Task<IActionResult> BlockUserAsync(Guid id)
        {
            await _mediatorHandler.SendAsync(new BlockUserCommand() { IdUser = id });

            return Ok(new { message = "Usuário bloqueado com sucesso." });
        }

        [Authorize("AdminOrAttendant")]
        [HttpPatch("Unblock/{id}")]
        public async Task<IActionResult> UnblockUserAsync(Guid id)
        {
            await _mediatorHandler.SendAsync(new UnblockUserCommand() { IdUser = id });

            return Ok(new { message = "Usuário desbloqueado com sucesso." });
        }

        [Authorize("AdminOrAttendant")]
        [HttpPatch("Fine/{id}")]
        public async Task<IActionResult> RemoveFineAsync(Guid id)
        {
            await _mediatorHandler.SendAsync(new RemoveFineCommand() { IdUser = id });
            
            return Ok(new { message = "Multa removida com sucesso." });
        }

        [Authorize("Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            await _mediatorHandler.SendAsync(new DeleteUserCommand() { IdUser = id, Role = (UserRole)_userData.UserRole });

            return Ok(new { message = "Usuário excluído com sucesso." });
        }
    }
}