using CommandService.CommandModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueryService.QueryModels;
using System;
using System.Threading.Tasks;
using ViewModels.View;

namespace Deathmatch.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task CreateSession(CreateSessionCommand cmd)
        {
            await _mediator.Send(cmd);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllSessionsQuery());
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task RemoveSession(Guid id)
        {
            await _mediator.Send(new RemoveSessionByIdCommand(id));
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task RemoveUserFromSession(RemoveUserFromSessionCommand cmd)
        {
            await _mediator.Send(cmd);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task JoinSession(JoinSessionCommand cmd)
        {
            await _mediator.Send(cmd);
        }
    }
}
