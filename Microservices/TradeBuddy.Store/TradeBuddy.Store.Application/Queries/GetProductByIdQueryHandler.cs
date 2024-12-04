using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TradeBuddy.Store.Application.Dto;
using TradeBuddy.Store.Domain.Interfaces;


namespace TradeBuddy.Store.Application.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto>
    {
        private readonly IRepository<Product, Guid> _productRepository;

        public GetProductByIdQueryHandler(IRepository<Product, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.ProductId);

            if (product == null)
                return null;

            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name?.Value,
                Price = product.Price.Value,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name.Value,
                BrandId = product.BrandId,
                BrandName = product.Brand?.Name.Value
            };
        }
    }
}
