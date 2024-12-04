using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Store.Application.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid BrandId { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
    }

}
