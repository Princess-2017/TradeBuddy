using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.Interfaces;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddFeatureToVariantHandler : IRequestHandler<AddFeatureToVariantCommand, Guid>
    {
        private readonly IRepository<ProductVariantFeature, Guid> _productVariantFeatureRepository;

        public AddFeatureToVariantHandler(IRepository<ProductVariantFeature, Guid> productVariantFeatureRepository)
        {
            _productVariantFeatureRepository = productVariantFeatureRepository;
        }

        public async Task<Guid> Handle(AddFeatureToVariantCommand request, CancellationToken cancellationToken)
        {
            var productVariantFeature = new ProductVariantFeature
            {
                Id = Guid.NewGuid(),
                ProductVariantId = request.VariantId,
                FeatureId = request.FeatureId,
                FeatureValueId = request.FeatureValueId,
                StoreId = request.StoreId
            };

            await _productVariantFeatureRepository.AddAsync(productVariantFeature);
            return productVariantFeature.Id;
        }
    }
}
