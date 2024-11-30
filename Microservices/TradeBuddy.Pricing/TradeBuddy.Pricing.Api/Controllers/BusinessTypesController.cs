using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeBuddy.Pricing.Application.Commands;
using TradeBuddy.Pricing.Application.Queries;

namespace TradeBuddy.Pricing.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusinessTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBusinessType([FromBody] CreateBusinessTypeCommand command)
        {
            var businessTypeId = await _mediator.Send(command);
            return Ok(businessTypeId);
        }

        [HttpGet]
        public async Task<IActionResult> GetBusinessTypes()
        {
            var businessTypes = await _mediator.Send(new GetBusinessTypesQuery());
            return Ok(businessTypes);
        }
    }
}
