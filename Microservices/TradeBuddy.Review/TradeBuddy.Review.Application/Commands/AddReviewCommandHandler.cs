using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Review.Domain.Entities;
using TradeBuddy.Review.Domain.Interfaces;
using TradeBuddy.Review.Domain.ValueObjects;

namespace TradeBuddy.Review.Application.Commands
{
    public class AddReviewCommandHandler : IRequestHandler<AddReviewCommand, long>
    {

        private readonly IRepository<TradeBuddy.Review.Domain.Entities.Review, long> _reviewRepository;

        public AddReviewCommandHandler(IRepository<TradeBuddy.Review.Domain.Entities.Review, long> reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }
        public async Task<long> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var rating = new Rating(request.Rating);
            var review = new TradeBuddy.Review.Domain.Entities.Review(request.BusinessId, request.UserId, rating, request.Comment);

            await _reviewRepository.AddAsync(review);
            return review.Id;
        }
    }
}
