using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeBuddy.Pricing.Application.Commands;
using TradeBuddy.Pricing.Application.Dto;

namespace TradeBuddy.Pricing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount([FromBody] DiscountCreateDto dto)
        {
            var result = await _mediator.Send(new CreateDiscountCommand(dto));
            return Ok(result); // Returns the ID of the created discount
        }

    }
}
