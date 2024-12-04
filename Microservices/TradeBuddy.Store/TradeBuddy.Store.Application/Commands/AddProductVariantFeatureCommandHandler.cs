using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Store.Application.Commands;
using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.Interfaces;

namespace TradeBuddy.Store.Application.ProductVariantFeatures.Commands
{
    public class AddProductVariantFeatureCommandHandler : IRequestHandler<AddProductVariantFeatureCommand, Guid>
    {
        private readonly IRepository<ProductVariantFeature, Guid> _variantFeatureRepository;

        public AddProductVariantFeatureCommandHandler(IRepository<ProductVariantFeature, Guid> variantFeatureRepository)
        {
            _variantFeatureRepository = variantFeatureRepository;
        }

        public async Task<Guid> Handle(AddProductVariantFeatureCommand request, CancellationToken cancellationToken)
        {
            var variantFeature = new ProductVariantFeature
            {
                ProductVariantId = request.ProductVariantId,
                FeatureId = request.FeatureId,
                FeatureValueId = request.FeatureValueId
            };

            await _variantFeatureRepository.AddAsync(variantFeature);
            return variantFeature.Id;
        }
    }
}
