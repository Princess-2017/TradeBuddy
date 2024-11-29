using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Review.Application.Dto;
using TradeBuddy.Review.Domain.Interfaces;
using System.Linq.Expressions;
using TradeBuddy.Review.Application.Exceptions; // اضافه کردن namespace برای استفاده از Extension

namespace TradeBuddy.Review.Application.Queries
{
    public class GetReviewsQueryHandler : IRequestHandler<GetReviewsQuery, List<ReviewDto>>
    {
        private readonly IRepository<TradeBuddy.Review.Domain.Entities.Review, Guid> _reviewRepository;

        public GetReviewsQueryHandler(IRepository<TradeBuddy.Review.Domain.Entities.Review, Guid> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<List<ReviewDto>> Handle(GetReviewsQuery request, CancellationToken cancellationToken)
        {
            // جستجو بر اساس BusinessId
            Expression<Func<TradeBuddy.Review.Domain.Entities.Review, bool>> predicate = r => r.BusinessId == request.BusinessId;

            var reviews = await _reviewRepository.SearchAsync(predicate);

            return reviews.Select(r => new ReviewDto
            {
                ReviewId = Guid.NewGuid(),
                Rating = r.Rating.Value,
                Comment = r.Comment,
                CreatedAt = r.CreateDate.ToPersianDateString() // تبدیل به تاریخ شمسی
            }).ToList();
        }
    }
}
