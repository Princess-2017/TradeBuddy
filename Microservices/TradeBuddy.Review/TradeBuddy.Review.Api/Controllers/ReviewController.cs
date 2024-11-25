using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TradeBuddy.Review.Application.Commands;
using TradeBuddy.Review.Application.Queries;
using TradeBuddy.Review.Application.Dto;

namespace TradeBuddy.Review.Api.Controller
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// دریافت نظرات برای یک کسب و کار خاص
        /// </summary>
        /// <param name="businessId">شناسه کسب و کار</param>
        /// <returns>لیست نظرات</returns>
        [HttpGet]
        public async Task<IActionResult> GetReviews(Guid businessId)
        {
            var query = new GetReviewsQuery { BusinessId = businessId };
            var reviews = await _mediator.Send(query);

            return Ok(reviews);
        }

        /// <summary>
        /// ارسال نظر جدید برای یک کسب و کار
        /// </summary>
        /// <param name="command">دستور برای ارسال نظر جدید</param>
        /// <returns>شناسه نظر جدید</returns>
        [HttpPost]
        public async Task<IActionResult> AddReview([FromBody] AddReviewCommand command)
        {
            if (command == null)
            {
                return BadRequest("داده‌های ورودی معتبر نیست.");
            }

            var reviewId = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetReviews), new { businessId = command.BusinessId }, reviewId);
        }
    }
}
