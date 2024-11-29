using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Store.Domain.Entities
{
    public class ProductVariant : BaseEntity<Guid>
    {
        public Guid ProductId { get; set; } // ارجاع به محصول اصلی
        public int StockQuantity { get; set; } // تعداد موجودی
        public decimal VariantPrice { get; set; } // قیمت خاص این ترکیب ویژگی‌ها

        // ویژگی‌های این ترکیب محصول
        public virtual List<ProductVariantFeature> ProductVariantFeatures { get; set; } = new List<ProductVariantFeature>();

        public virtual Product Product { get; set; }
        public virtual List<ProductStock> ProductStocks { get; set; }
    }

}
