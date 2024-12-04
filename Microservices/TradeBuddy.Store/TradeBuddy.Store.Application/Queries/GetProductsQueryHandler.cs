using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Store.Application.Dto;
using TradeBuddy.Store.Domain.Interfaces;

namespace TradeBuddy.Store.Application.Queries
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IRepository<Product, Guid> _productRepository;

        public GetProductsQueryHandler(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllAsync();

            if (request.CategoryId.HasValue)
            {
                products = products.Where(p => p.CategoryId == request.CategoryId.Value).ToList();
            }

            if (request.BrandId.HasValue)
            {
                products = products.Where(p => p.BrandId == request.BrandId.Value).ToList();
            }


            products = products.Where(p => p.StoreId == request.StoreId).ToList();


            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name.Value,
                Price = p.Price.Value,
                CategoryId = p.CategoryId,
                BrandId = p.BrandId
            }).ToList();
        }
    }
}
