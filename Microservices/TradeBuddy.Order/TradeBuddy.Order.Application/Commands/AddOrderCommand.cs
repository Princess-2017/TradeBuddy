using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Order.Application.Dto;

namespace TradeBuddy.Order.Application.Commands
{
    public class AddOrderCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderType { get; set; } // "Product" or "Service"
        public List<CreateOrderItemDto> Items { get; set; }
    }
}
