using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueryService.QueryModels;
using System;
using System.Threading.Tasks;

namespace Deathmatch.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserInSessionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserInSessionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{sessionId}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUsersInParticularSession(Guid sessionId)
        {
            var result = await _mediator.Send(new GetUsersInParticularSessionQuery(sessionId));
            return Ok(result);
        }
    }
}
