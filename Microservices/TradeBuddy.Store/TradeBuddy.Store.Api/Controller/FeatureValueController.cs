using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradeBuddy.Store.Application.Commands;
using TradeBuddy.Store.Application.Commands;
using TradeBuddy.Store.Application.Queries;

namespace TradeBuddy.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureValueController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeatureValueController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddFeatureValue([FromBody] AddFeatureValueCommand command)
        {
            if (command == null)
                return BadRequest("Invalid feature value data.");

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetFeatureValueById), new { id = result }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureValueById(Guid id)
        {
            var query = new GetFeatureValueByIdQuery { FeatureValueId = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
