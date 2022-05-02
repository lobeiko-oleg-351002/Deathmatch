using CommandService.CommandModels;
using MediatR;
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
        public async Task CreateSession(CreateSessionCommand cmd)
        {
            await _mediator.Send(cmd);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllSessionsQuery());
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task RemoveSession(Guid id)
        {
            await _mediator.Send(new RemoveSessionByIdCommand(id));
        }

        [HttpPost]
        public async Task RemoveUserFromSession(RemoveUserFromSessionCommand cmd)
        {
            await _mediator.Send(cmd);
        }
    }
}
