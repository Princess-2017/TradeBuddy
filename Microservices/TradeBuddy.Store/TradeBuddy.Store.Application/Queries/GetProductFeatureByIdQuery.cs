using MediatR;
using System;
using TradeBuddy.Store.Application.Dto;

namespace TradeBuddy.Store.Application.Queries
{
    public class GetProductFeatureByIdQuery : IRequest<ProductFeatureDto>
    {
        public Guid ProductFeatureId { get; set; }
    }
}
