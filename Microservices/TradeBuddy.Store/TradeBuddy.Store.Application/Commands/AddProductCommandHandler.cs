using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Store.Domain.Interfaces;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Guid>
    {
        private readonly IRepository<Product, Guid> _productRepository;

        public AddProductCommandHandler(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = new Domain.ValueObjects.ProductName(request.Name),
                Price = new Domain.ValueObjects.Price(request.Price),
                CategoryId = request.CategoryId,
                BrandId = request.BrandId
            };
            await _productRepository.AddAsync(product);
            return product.Id;
        }
    }
}
