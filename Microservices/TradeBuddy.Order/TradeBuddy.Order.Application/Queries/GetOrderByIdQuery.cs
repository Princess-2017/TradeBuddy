using MediatR;

namespace TradeBuddy.Review.Application.Queries
{
    public class GetOrderByIdQuery : IRequest<TradeBuddy.Order.Domain.Entities.Order>
    {
        public Guid Id { get; set; }
    }
}
