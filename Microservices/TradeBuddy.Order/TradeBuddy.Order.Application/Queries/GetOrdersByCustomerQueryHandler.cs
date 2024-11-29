using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Order.Domain.Entities;
using TradeBuddy.Order.Domain.Interfaces;

namespace TradeBuddy.Order.Application.Queries
{
    public class GetOrdersByCustomerQueryHandler : IRequestHandler<GetOrdersByCustomerQuery, IEnumerable<TradeBuddy.Order.Domain.Entities.Order>>
    {
        private readonly IRepository<TradeBuddy.Order.Domain.Entities.Order, Guid> _orderRepository;

        public GetOrdersByCustomerQueryHandler(IRepository<TradeBuddy.Order.Domain.Entities.Order, Guid> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<TradeBuddy.Order.Domain.Entities.Order>> Handle(GetOrdersByCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.SearchAsync(o => o.CustomerId == request.CustomerId);
        }
    }
}
