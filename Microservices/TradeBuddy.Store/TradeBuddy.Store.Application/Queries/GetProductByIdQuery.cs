using MediatR;
using System;
using TradeBuddy.Store.Application.Dto;

namespace TradeBuddy.Store.Application.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto>
    {
        public Guid ProductId { get; set; }

        public GetProductByIdQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
