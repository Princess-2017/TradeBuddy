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
    public class ServicePackagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicePackagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/ServicePackages
        [HttpPost]
        public async Task<IActionResult> CreateServicePackage([FromBody] CreateServicePackageCommand command)
        {
            // ارسال درخواست برای ایجاد ServicePackage
            var servicePackageId = await _mediator.Send(command);

            // بازگشت به درخواست با شناسه ایجاد شده
            return CreatedAtAction(nameof(GetServicePackageById), new { id = servicePackageId }, command);
        }

        // GET api/ServicePackages/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetServicePackageById(int id)
        {
            // ارسال درخواست برای دریافت ServicePackage با شناسه خاص
            var query = new GetServicePackageByIdQuery { Id = id };
            var servicePackage = await _mediator.Send(query);

            if (servicePackage == null)
            {
                return NotFound();
            }

            return Ok(servicePackage);
        }

        // GET api/ServicePackages
        [HttpGet]
        public async Task<IActionResult> GetServicePackages([FromQuery] GetServicePackagesQuery request)
        {
            // ارسال درخواست برای دریافت همه ServicePackages با فیلترهای مختلف
            var servicePackages = await _mediator.Send(request);
            return Ok(servicePackages);
        }
    }
}
