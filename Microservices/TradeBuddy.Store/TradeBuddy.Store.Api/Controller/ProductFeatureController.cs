using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradeBuddy.Store.Application.Commands;
using TradeBuddy.Store.Application.Queries;

namespace TradeBuddy.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductFeature([FromBody] AddProductFeatureCommand command)
        {
            if (command == null)
                return BadRequest("Invalid product feature data.");

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductFeatureById), new { id = result }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductFeatureById(Guid id)
        {
            // Implement the logic to fetch ProductFeature by ID
            return Ok(); // Replace with actual result
        }
    }
}
