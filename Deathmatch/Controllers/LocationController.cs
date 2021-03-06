using CommandService.CommandModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QueryService.QueryModels;
using System;
using System.Threading.Tasks;

namespace Deathmatch.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task CreateLocation(CreateLocationCommand cmd)
        {
            await _mediator.Send(cmd);
        }

      //  [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllLocationsQuery());
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task RemoveLocation(Guid id)
        {
            await _mediator.Send(new RemoveLocationByIdCommand(id));
        }
    }
}
