using MediatR;
using Microsoft.AspNetCore.Mvc;
using QueryService.QueryModels;
using System.Threading.Tasks;

namespace Deathmatch.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RoleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //  [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllRolesQuery());
            return Ok(result);
        }
    }
}
