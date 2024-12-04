using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeBuddy.Store.Application.Commands;
using TradeBuddy.Store.Application.Queries;
using TradeBuddy.Store.Application.Dto;

namespace TradeBuddy.Store.Api.Controller
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand([FromBody] AddBrandCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result); // Returns the GUID of the added brand
        }
    }
}
