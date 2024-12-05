using Microsoft.AspNetCore.Mvc;
using MediatR;
using TradeBuddy.Business.Application.Queries.Services;
using TradeBuddy.Business.Application.Commands.Services;

namespace TradeBuddy.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // دریافت همه خدمات
        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
            var services = await _mediator.Send(new GetAllServicesQuery());
            return Ok(services);
        }

        // دریافت یک خدمت بر اساس Id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceById(Guid id)
        {
            var service = await _mediator.Send(new GetServiceByIdQuery(id));
            if (service == null)
                return NotFound();
            return Ok(service);
        }

        // ایجاد یک خدمت جدید
        [HttpPost]
        public async Task<IActionResult> CreateService([FromBody] AddServiceCommand command)
        {
            var createdServiceId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetServiceById), new { id = createdServiceId }, createdServiceId);
        }

        // ویرایش یک خدمت
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateService(Guid id, [FromBody] UpdateServiceCommand command)
        {
            if (id != command.Id)
                return BadRequest("Service ID mismatch.");

            await _mediator.Send(command);
            return NoContent();
        }

        // حذف یک خدمت
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(Guid id)
        {
            await _mediator.Send(new DeleteServiceCommand(id));
            return NoContent();
        }
    }
}
