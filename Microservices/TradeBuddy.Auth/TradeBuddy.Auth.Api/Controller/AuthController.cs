using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TradeBuddy.Auth.Application.Commands.User;
using TradeBuddy.Auth.Application.Queries;
using TradeBuddy.Business.Application.Queries.User;

namespace TradeBuddy.Auth.Api.Controllers
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



    }
}
