using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TradeBuddy.Business.Application.Commands.Categories;
using TradeBuddy.Business.Application.Queries.Categories;

namespace TradeBuddy.Business.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// دریافت تمامی دسته‌بندی‌ها
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _mediator.Send(new GetCategoriesQuery());
            return Ok(result);
        }

        /// <summary>
        /// دریافت اطلاعات دسته‌بندی بر اساس شناسه
        /// </summary>
        /// <param name="id">شناسه دسته‌بندی</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(Guid id)
        {
            var query = new GetCategoryByIdQuery { CategoryId = id };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound($"دسته‌بندی با شناسه {id} یافت نشد.");

            return Ok(result);
        }

        /// <summary>
        /// اضافه کردن دسته‌بندی جدید
        /// </summary>
        /// <param name="command">اطلاعات دسته‌بندی</param>
        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest("اطلاعات وارد شده نامعتبر است.");

            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCategoryById), new { id = result }, $"دسته‌بندی با موفقیت ایجاد شد. شناسه: {result}");
        }

        /// <summary>
        /// به‌روزرسانی دسته‌بندی
        /// </summary>
        /// <param name="id">شناسه دسته‌بندی</param>
        /// <param name="command">اطلاعات جدید دسته‌بندی</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryCommand command)
        {
            if (id != command.CategoryId)
                return BadRequest("شناسه موجود در URL با شناسه وارد شده در داده‌ها همخوانی ندارد.");

            if (!ModelState.IsValid)
                return BadRequest("اطلاعات وارد شده نامعتبر است.");

            var result = await _mediator.Send(command);

            if (!result)
                return NotFound($"دسته‌بندی با شناسه {id} یافت نشد.");

            return Ok("دسته‌بندی با موفقیت به‌روزرسانی شد.");
        }

        /// <summary>
        /// حذف دسته‌بندی
        /// </summary>
        /// <param name="id">شناسه دسته‌بندی</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var command = new DeleteCategoryCommand { CategoryId = id };
            var result = await _mediator.Send(command);

            if (!result)
                return NotFound($"دسته‌بندی با شناسه {id} یافت نشد.");

            return Ok("دسته‌بندی با موفقیت حذف شد.");
        }
    }
}
