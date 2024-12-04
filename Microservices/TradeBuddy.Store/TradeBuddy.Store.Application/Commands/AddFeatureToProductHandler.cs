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
    public class AddFeatureToProductHandler : IRequestHandler<AddFeatureToProductCommand, Guid>
    {
        private readonly IRepository<ProductFeature, Guid> _productFeatureRepository;

        public AddFeatureToProductHandler(IRepository<ProductFeature, Guid> productFeatureRepository)
        {
            _productFeatureRepository = productFeatureRepository;
        }

        public async Task<Guid> Handle(AddFeatureToProductCommand request, CancellationToken cancellationToken)
        {
            var productFeature = new ProductFeature
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                FeatureId = request.FeatureId,
                FeatureValueId = request.FeatureValueId,
                StoreId = request.StoreId
            };

            await _productFeatureRepository.AddAsync(productFeature);
            return productFeature.Id;
        }
    }
}
