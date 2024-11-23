using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TradeBuddy.Auth.Application.Commands.User;
using TradeBuddy.Business.Application.Commands.Auth;
using TradeBuddy.Business.Application.Queries.Auth;

namespace TradeBuddy.Business.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// ثبت‌نام کاربر جدید
        /// </summary>
        /// <param name="command">اطلاعات ثبت‌نام کاربر</param>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest("اطلاعات وارد شده نامعتبر است.");

            var result = await _mediator.Send(command);
            if (result == null)
                return BadRequest("خطا در ایجاد حساب کاربری.");

            return CreatedAtAction(nameof(Login), new { username = command.Username }, "حساب کاربری با موفقیت ایجاد شد.");
        }

        /// <summary>
        /// ورود به سیستم
        /// </summary>
        /// <param name="command">اطلاعات ورود کاربر</param>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            if (!ModelState.IsValid)
                return BadRequest("اطلاعات وارد شده نامعتبر است.");

            var result = await _mediator.Send(command);
            if (result == null)
                return Unauthorized("نام کاربری یا رمز عبور اشتباه است.");

            return Ok(result); // توکن JWT یا اطلاعات کاربر باز می‌گردد
        }

        /// <summary>
        /// دریافت اطلاعات کاربر
        /// </summary>
        [HttpGet("me")]
        public async Task<IActionResult> GetUserInfo()
        {
            var userId = User.Identity.Name; // فرض بر این است که نام کاربری به عنوان شناسه ذخیره شده باشد
            if (string.IsNullOrEmpty(userId))
                return Unauthorized("شما وارد نشده‌اید.");

            var query = new GetUserInfoQuery { UserId = userId };
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound("کاربری با این شناسه پیدا نشد.");

            return Ok(result);
        }
    }
}
