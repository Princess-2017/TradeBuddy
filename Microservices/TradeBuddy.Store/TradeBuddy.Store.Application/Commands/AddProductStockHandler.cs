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
    public class AddProductStockHandler : IRequestHandler<AddProductStockCommand, Guid>
    {
        private readonly IRepository<ProductStock, Guid> _productStockRepository;

        public AddProductStockHandler(IRepository<ProductStock, Guid> productStockRepository)
        {
            _productStockRepository = productStockRepository;
        }

        public async Task<Guid> Handle(AddProductStockCommand request, CancellationToken cancellationToken)
        {
            var productStock = new ProductStock
            {
                Id = Guid.NewGuid(),
                StoreId = request.StoreId,
                ProductId = request.ProductId,
                ProductVariantId = request.ProductVariantId,
                TotalStock = request.TotalStock
            };

            await _productStockRepository.AddAsync(productStock);
            return productStock.Id;
        }
    }
}
