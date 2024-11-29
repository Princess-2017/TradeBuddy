using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Review.Domain.Entities;
using TradeBuddy.Review.Domain.Enums;
using TradeBuddy.Review.Domain.Interfaces;
using TradeBuddy.Review.Domain.ValueObjects;

namespace TradeBuddy.Review.Application.Commands
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, Guid>
    {

        private readonly IRepository<TradeBuddy.Review.Domain.Entities.Review, Guid> _reviewRepository;

        public AddReviewCommandHandler(IRepository<TradeBuddy.Review.Domain.Entities.Review, Guid> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<Guid> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var rating = new Rating(request.Rating);
            var review = new TradeBuddy.Review.Domain.Entities.Review(
                request.BusinessId, request.UserId, rating, request.Comment,ReviewType.Business);

            await _reviewRepository.AddAsync(review);
            return review.Id;
        }
    }
}
