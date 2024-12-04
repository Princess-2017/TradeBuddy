using MediatR;
using TradeBuddy.Store.Application.Dto;

namespace TradeBuddy.Store.Application.Queries
{
    public class GetProductsQuery : IRequest<List<ProductDto>>
    {
        public Guid? CategoryId { get; set; }
        public Guid? BrandId { get; set; }

        public Guid StoreId { get; set; }
        public GetProductsQuery(Guid? categoryId = null, Guid? brandId = null, Guid storeId = default)
        {
            CategoryId = categoryId;
            BrandId = brandId;
            StoreId = storeId;
        }
    }
}
