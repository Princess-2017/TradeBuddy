using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradeBuddy.Store.Application.Commands;

namespace TradeBuddy.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantFeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductVariantFeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductVariantFeature([FromBody] AddProductVariantFeatureCommand command)
        {
            if (command == null)
                return BadRequest("Invalid product variant feature data.");

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductVariantFeatureById), new { id = result }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductVariantFeatureById(Guid id)
        {
            // Implement the logic to fetch ProductVariantFeature by ID
            return Ok(); // Replace with actual result
        }
    }
}
