using MediatR;
using TradeBuddy.Store.Application.Dto;
using TradeBuddy.Store.Domain.ValueObjects;

namespace TradeBuddy.Store.Application.Queries
{
    public class GetAllFeaturesQuery : IRequest<List<FeatureDto>>
    {
        public Guid StoreId { get; set; }
        public GetAllFeaturesQuery(Guid storeId = default)
        {
            StoreId = storeId;
        }
    }
}
