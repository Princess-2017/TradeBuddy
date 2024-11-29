using MediatR;
using TradeBuddy.Order.Domain.Entities;
using TradeBuddy.Order.Domain.Interfaces;

namespace TradeBuddy.Review.Application.Queries
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, TradeBuddy.Order.Domain.Entities.Order>
    {
        private readonly IRepository<TradeBuddy.Order.Domain.Entities.Order, Guid> _repository;

        public GetOrderByIdQueryHandler(IRepository<TradeBuddy.Order.Domain.Entities.Order, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<TradeBuddy.Order.Domain.Entities.Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
