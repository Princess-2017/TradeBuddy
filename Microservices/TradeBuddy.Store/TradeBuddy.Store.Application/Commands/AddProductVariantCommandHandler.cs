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
    public class AddProductVariantCommandHandler : IRequestHandler<AddProductVariantCommand, Guid>
    {
        private readonly IRepository<ProductVariant, Guid> _productVariantRepository;

        public AddProductVariantCommandHandler(IRepository<ProductVariant, Guid> productVariantRepository)
        {
            _productVariantRepository = productVariantRepository;
        }

        public async Task<Guid> Handle(AddProductVariantCommand request, CancellationToken cancellationToken)
        {
            var productVariant = new ProductVariant
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                StockQuantity = request.StockQuantity,
                VariantPrice = request.VariantPrice,
                ProductVariantFeatures = request.ProductVariantFeatures.Select(f => new ProductVariantFeature
                {
                    Id = Guid.NewGuid(),
                    FeatureId = f.FeatureId,
                    FeatureValueId = f.FeatureValueId
                }).ToList()
            };

            await _productVariantRepository.AddAsync(productVariant);
            return productVariant.Id;
        }
    }

}
