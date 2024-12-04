using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Store.Application.Dto;
using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.Interfaces;

namespace TradeBuddy.Store.Application.Queries
{
    public class GetProductFeatureByIdQueryHandler : IRequestHandler<GetProductFeatureByIdQuery, ProductFeatureDto>
    {
        private readonly IRepository<ProductFeature, Guid> _productFeatureRepository;

        public GetProductFeatureByIdQueryHandler(IRepository<ProductFeature, Guid> productFeatureRepository)
        {
            _productFeatureRepository = productFeatureRepository;
        }

        public async Task<ProductFeatureDto> Handle(GetProductFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var productFeature = await _productFeatureRepository.GetByIdAsync(request.ProductFeatureId);

            if (productFeature == null)
                return null;

            return new ProductFeatureDto
            {
                Id = productFeature.Id,
                ProductId = productFeature.ProductId,
                FeatureId = productFeature.FeatureId,
                FeatureValueId = productFeature.FeatureValueId
            };
        }
    }
}
