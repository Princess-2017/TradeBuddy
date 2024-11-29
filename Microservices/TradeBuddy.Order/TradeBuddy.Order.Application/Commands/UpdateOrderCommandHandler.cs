using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Order.Domain.Entities;
using TradeBuddy.Order.Domain.Interfaces;

namespace TradeBuddy.Order.Application.Commands
{

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand,Guid>
    {
        private readonly IRepository<TradeBuddy.Order.Domain.Entities.Order, Guid> _orderRepository;

        public UpdateOrderCommandHandler(IRepository<TradeBuddy.Order.Domain.Entities.Order, Guid> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Guid> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            if (order != null)
            {
                order.CompleteOrder(); // Assuming the status is "Completed"
                
                await _orderRepository.UpdateAsync(order);
            }
            return order.Id;
        }
    }
}
