using MediatR;
using TradeBuddy.Order.Domain.Entities;
using TradeBuddy.Order.Domain.Interfaces;

namespace TradeBuddy.Order.Application.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<AddOrderCommand, Guid>
    {
        private readonly IRepository<TradeBuddy.Order.Domain.Entities.Order, Guid> _orderRepository;
        private readonly IRepository<OrderItem, Guid> _orderItemRepository;

        public CreateOrderCommandHandler(IRepository<TradeBuddy.Order.Domain.Entities.Order, Guid> orderRepository, IRepository<OrderItem, Guid> orderItemRepository)
        {
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
        }

        public async Task<Guid> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new TradeBuddy.Order.Domain.Entities.Order(Guid.NewGuid(), request.CustomerId, request.OrderDate, request.OrderType);

            foreach (var itemDto in request.Items)
            {
                var orderItem = new OrderItem(Guid.NewGuid(), itemDto.ProductId, itemDto.Quantity, itemDto.UnitPrice, order.Id, itemDto.Tax, itemDto.Insurance, itemDto.ServiceDuration);
                order.AddItem(orderItem);
                await _orderItemRepository.AddAsync(orderItem);  // Adding item to database
            }

            await _orderRepository.AddAsync(order); // Adding order to database
            return order.Id;
        }
    }

}
