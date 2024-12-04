using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeBuddy.Pricing.Application.Commands;
using TradeBuddy.Pricing.Application.Dto;

namespace TradeBuddy.Pricing.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IndustryCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IndustryCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateIndustryCategory([FromBody] IndustryCategoryCreateDto dto)
        {
            var result = await _mediator.Send(new CreateIndustryCategoryCommand(dto));
            return Ok(result); // Returns the ID of the created industry category
        }
    }
}
