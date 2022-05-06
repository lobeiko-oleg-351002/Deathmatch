using CommandService.CommandModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QueryService.QueryModels;
using System.Threading.Tasks;

namespace Deathmatch.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task CreateUser(CreateUserCommand cmd)
        {
            await _mediator.Send(cmd);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Authentificate(string username, string password)
        {
            var result = await _mediator.Send(new AuthorizeQuery(username, password));
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task RemoveUser(RemoveUserByIdCommand cmd)
        {
            await _mediator.Send(cmd);
        }
    }
}
