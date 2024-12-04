using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeBuddy.Store.Application.Commands;
using System.Threading.Tasks;
using TradeBuddy.Store.Application.Commands;

namespace TradeBuddy.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductVariantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProductVariant([FromBody] AddProductVariantCommand command)
        {
            if (command == null)
                return BadRequest("Invalid data");

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetProductVariantById), new { id = result }, result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductVariantById(Guid id)
        {
            // TODO: Implement Query to get ProductVariant by ID
            return Ok(); // Replace with actual result
        }

        // Optionally, add more actions like Update or Delete
    }
}
