using MediatR;
using System;

namespace TradeBuddy.Order.Application.Commands
{
    public class DeleteOrderCommand : IRequest<Guid>
    {
        public Guid OrderId { get; set; }
    }
}
