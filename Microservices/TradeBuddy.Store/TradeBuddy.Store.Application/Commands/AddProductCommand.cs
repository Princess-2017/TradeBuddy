using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public Guid StoreId { get; set; }

        public AddProductCommand(string name, decimal price, Guid categoryId, Guid brandId, Guid storeId)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
            BrandId = brandId;
            StoreId = storeId;
        }
    }
}
