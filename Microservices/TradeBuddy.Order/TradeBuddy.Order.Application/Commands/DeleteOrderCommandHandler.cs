using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Order.Domain.Interfaces;

namespace TradeBuddy.Order.Application.Commands
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand,Guid>
    {
        private readonly IRepository<TradeBuddy.Order.Domain.Entities.Order, Guid> _repository;

        public DeleteOrderCommandHandler(IRepository<TradeBuddy.Order.Domain.Entities.Order, Guid> repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            // دریافت سفارش با ID
            var order = await _repository.GetByIdAsync(request.OrderId);
            if (order == null)
            {
                throw new Exception("Order not found."); // یا یک Exception مناسب‌تر
            }

            // حذف منطقی
            order.MarkAsDeleted();

            // به‌روزرسانی سفارش
            await _repository.UpdateAsync(order);

            return order.Id;
        }
    }
}
