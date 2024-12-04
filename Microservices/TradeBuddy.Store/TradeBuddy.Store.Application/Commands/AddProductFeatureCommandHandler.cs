using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.Interfaces;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddProductFeatureCommandHandler : IRequestHandler<AddProductFeatureCommand, Guid>
    {
        private readonly IRepository<ProductFeature, Guid> _productFeatureRepository;

        public AddProductFeatureCommandHandler(IRepository<ProductFeature, Guid> productFeatureRepository)
        {
            _productFeatureRepository = productFeatureRepository;
        }

        public async Task<Guid> Handle(AddProductFeatureCommand request, CancellationToken cancellationToken)
        {
            var productFeature = new ProductFeature
            {
                ProductId = request.ProductId,
                FeatureId = request.FeatureId,
                FeatureValueId = request.FeatureValueId
            };

            await _productFeatureRepository.AddAsync(productFeature);
            return productFeature.Id;
        }
    }
}
