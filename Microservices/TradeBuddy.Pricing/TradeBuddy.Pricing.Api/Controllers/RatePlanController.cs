using TradeBuddy.Pricing.Application.Commands;
using TradeBuddy.Pricing.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TradeBuddy.Pricing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatePlanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RatePlanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRatePlan([FromBody] RatePlanCreateDto dto)
        {
            var result = await _mediator.Send(new CreateRatePlanCommand(dto));
            return Ok(result); // Returns the ID of the created rate plan
        }

        [HttpPost("feature")]
        public async Task<IActionResult> CreateRatePlanFeature([FromBody] RatePlanFeatureCreateDto dto)
        {
            var result = await _mediator.Send(new CreateRatePlanFeatureCommand(dto));
            return Ok(result); // Returns the ID of the created rate plan feature
        }
    }
}

