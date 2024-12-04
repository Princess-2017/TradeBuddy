using MediatR;
using System;
using TradeBuddy.Store.Application.Dto;

namespace TradeBuddy.Store.Application.Queries
{
    public class GetFeatureValueByIdQuery : IRequest<FeatureValueDto>
    {
        public Guid FeatureValueId { get; set; }
    }
}
