using MediatR;
using System;
using TradeBuddy.Store.Application.Dto;

namespace TradeBuddy.Store.Application.Queries
{
    public class GetFeatureByIdQuery : IRequest<FeatureDto>
    {
        public Guid FeatureId { get; set; }
    }
}
