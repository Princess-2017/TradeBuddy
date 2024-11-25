using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Review.Application.Dto;

namespace TradeBuddy.Review.Application.Queries
{
    public class GetReviewsQuery : IRequest<List<ReviewDto>>
    {
        public Guid BusinessId { get; set; }
    }
}
