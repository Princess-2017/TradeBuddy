using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TradeBuddy.Order.Application.Commands;
using TradeBuddy.Order.Application.Queries;
using TradeBuddy.Order.Domain.Entities;
using TradeBuddy.Review.Application.Queries;

namespace TradeBuddy.Order.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/order/{id}
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var query = new GetOrderByIdQuery { Id = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // GET: api/order/customer/{customerId}
        [HttpGet("customer/{customerId:guid}")]
        public async Task<IActionResult> GetOrdersByCustomerId(Guid customerId)
        {
            var query = new GetOrdersByCustomerQuery { CustomerId = customerId };
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        // POST: api/order
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] AddOrderCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var orderId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderId }, null);
        }

        // PUT: api/order/{id}
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] UpdateOrderCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != command.OrderId)
                return BadRequest("Order ID mismatch.");

            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE: api/order/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var command = new DeleteOrderCommand { OrderId = id };
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
