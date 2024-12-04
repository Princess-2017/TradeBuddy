using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeBuddy.Pricing.Application.Commands;
using TradeBuddy.Pricing.Application.Dto;

namespace TradeBuddy.Pricing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PricingPlanController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingPlanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricingPlan([FromBody] PricingPlanCreateDto dto)
        {
            var result = await _mediator.Send(new CreatePricingPlanCommand(dto));
            return Ok(result); // Returns the ID of the created pricing plan
        }
    }
}
