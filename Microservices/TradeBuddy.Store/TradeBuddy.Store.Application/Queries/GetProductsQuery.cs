using MediatR;
using TradeBuddy.Store.Application.Dto;

namespace TradeBuddy.Store.Application.Queries
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
        public Guid? CategoryId { get; set; }
        public Guid? BrandId { get; set; }

        public GetProductsQuery(Guid? categoryId = null, Guid? brandId = null)
        {
            CategoryId = categoryId;
            BrandId = brandId;
        }
    }
}
