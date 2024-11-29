using MediatR;
using System;
using System.Collections.Generic;

namespace TradeBuddy.Order.Application.Queries
{
    public class GetOrdersByCustomerQuery : IRequest<IEnumerable<TradeBuddy.Order.Domain.Entities.Order>>
    {
        public Guid CustomerId { get; set; }
    }
}
