using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeBuddy.Store.Application.Commands;
using TradeBuddy.Store.Application.Queries;
using TradeBuddy.Store.Application.Dto;

namespace TradeBuddy.Store.Api.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result); // Returns the GUID of the added product
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var result = await _mediator.Send(new DeleteProductCommand(id));
            return Ok(result); // Returns the GUID of the deleted product
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] Guid StoreId,[FromQuery] Guid? categoryId = null, [FromQuery] Guid? brandId = null)
        {
            var query = new GetProductsQuery(categoryId, brandId,StoreId);
            var products = await _mediator.Send(query);
            return Ok(products); // Returns the list of products
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetProductByIdQuery(id);
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

    }
}


