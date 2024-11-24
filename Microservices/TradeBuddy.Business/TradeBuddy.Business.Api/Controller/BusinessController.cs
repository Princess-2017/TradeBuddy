using Microsoft.AspNetCore.Mvc;
using MediatR;
using TradeBuddy.Business.Application.Commands.Business;
using TradeBuddy.Business.Application.Queries.Business;
using TradeBuddy.Business.Application.Commands.Categories;

namespace TradeBuddy.Business.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BusinessController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BusinessController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Business Endpoints

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBusinessById(Guid id)
        {
            var query = new GetBusinessQuery { BusinessId = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound($"کسب‌وکار با شناسه {id} یافت نشد.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddBusiness([FromBody] AddBusinessCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest("اطلاعات وارد شده نامعتبر است.");

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetBusinessById), new { id = result }, $"کسب‌وکار با موفقیت ایجاد شد. شناسه: {result}");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBusiness(Guid id, [FromBody] UpdateBusinessCommand command)
        {
            if (id != command.BusinessId)
                return BadRequest("شناسه موجود در URL با شناسه وارد شده در داده‌ها همخوانی ندارد.");

            if (!ModelState.IsValid)
                return BadRequest("اطلاعات وارد شده نامعتبر است.");

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound($"کسب‌وکار با شناسه {id} یافت نشد.");

            return Ok("اطلاعات کسب‌وکار با موفقیت به‌روزرسانی شد.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusiness(Guid id)
        {
            var command = new DeleteBusinessCommand { BusinessId = id };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound($"کسب‌وکار با شناسه {id} یافت نشد.");

            return Ok("کسب‌وکار با موفقیت حذف شد.");
        }

        #endregion

        #region BusinessType Endpoints

        /// <summary>
        /// دریافت نوع کسب‌وکار بر اساس شناسه
        /// </summary>
        [HttpGet("type")]
        public async Task<IActionResult> GetBusinessTypeById()
        {
            var query = new GetBusinessTypeQuery {};
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound($"نوع کسب و کاری یافت نشد");

            return Ok(result);
        }

        /// <summary>
        /// اضافه کردن نوع کسب‌وکار جدید
        /// </summary>
        [HttpPost("type")]
        public async Task<IActionResult> AddBusinessType([FromBody] AddBusinessTypeCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest("اطلاعات وارد شده نامعتبر است.");

            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetBusinessTypeById), new { id = result }, $"نوع کسب‌وکار با موفقیت ایجاد شد. شناسه: {result}");
        }

        /// <summary>
        /// حذف نوع کسب‌وکار بر اساس شناسه
        /// </summary>
        [HttpDelete("type/{id}")]
        public async Task<IActionResult> DeleteBusinessType(Guid id)
        {
            var command = new DeleteBusinessTypeCommand { BusinessTypeId = id };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound($"نوع کسب‌وکار با شناسه {id} یافت نشد.");

            return Ok("نوع کسب‌وکار با موفقیت حذف شد.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBusinesses([FromQuery] GetAllBusinessesQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        #endregion
    }
}
