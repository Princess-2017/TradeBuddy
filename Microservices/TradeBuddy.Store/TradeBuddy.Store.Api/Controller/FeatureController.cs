using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeBuddy.Store.Application.Commands;
using TradeBuddy.Store.Application.Queries;

namespace TradeBuddy.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddFeature([FromBody] AddFeatureCommand command)
        {
            if (command == null)
                return BadRequest("Invalid feature data.");

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetFeatureById), new { id = result }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureById(Guid id)
        {
            var query = new GetFeatureByIdQuery { FeatureId = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFeatures()
        {
            var result = await _mediator.Send(new GetAllFeaturesQuery());
            return Ok(result);
        }
    }
}
