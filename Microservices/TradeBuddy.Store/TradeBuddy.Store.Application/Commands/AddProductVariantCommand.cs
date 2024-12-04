using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Store.Application.Dto;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddProductVariantCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; } // ارجاع به محصول اصلی
        public int StockQuantity { get; set; } // تعداد موجودی
        public decimal VariantPrice { get; set; } // قیمت خاص این ترکیب ویژگی‌ها

        public List<ProductVariantFeatureDto> ProductVariantFeatures { get; set; } = new();
    }
}
