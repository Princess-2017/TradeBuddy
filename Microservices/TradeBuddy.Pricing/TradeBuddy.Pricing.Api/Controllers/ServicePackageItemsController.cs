using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using TradeBuddy.Pricing.Application.Commands;
using TradeBuddy.Pricing.Application.Queries;
using TradeBuddy.Pricing.Application.Dto;
using TradeBuddy.Pricing.Domain.Entities;

namespace TradeBuddy.Pricing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicePackageItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicePackageItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/ServicePackageItems
        [HttpPost]
        public async Task<IActionResult> CreateServicePackageItem([FromBody] CreateServicePackageItemCommand command)
        {
            // ارسال درخواست برای ایجاد ServicePackageItem
            var servicePackageItemId = await _mediator.Send(command);

            // بازگشت به درخواست با شناسه ایجاد شده
            return CreatedAtAction(nameof(GetServicePackageItemById), new { id = servicePackageItemId }, command);
        }

        // GET api/ServicePackageItems/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicePackageItemById(int id)
        {
            // ارسال درخواست برای دریافت ServicePackageItem با شناسه خاص
            var query = new GetServicePackageItemByIdQuery { Id = id };
            var servicePackageItem = await _mediator.Send(query);

            if (servicePackageItem == null)
            {
                return NotFound();
            }

            return Ok(servicePackageItem);
        }

        // GET api/ServicePackageItems/ByPackageId/{servicePackageId}
        [HttpGet("ByPackageId/{servicePackageId}")]
        public async Task<IActionResult> GetServicePackageItemsByPackageId(int servicePackageId)
        {
            // ارسال درخواست برای دریافت ServicePackageItems با شناسه ServicePackage خاص
            var query = new GetServicePackageItemsByPackageIdQuery { ServicePackageId = servicePackageId };
            var servicePackageItems = await _mediator.Send(query);

            return Ok(servicePackageItems);
        }
    }
}
