using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Store.Application.Commands
{
    public class AddProductStockCommand : IRequest<Guid>
    {
        public Guid StoreId { get; set; } // شناسه فروشگاه
        public Guid ProductId { get; set; } // شناسه محصول
        public Guid ProductVariantId { get; set; } // شناسه ترکیب ویژگی محصول
        public int TotalStock { get; set; } // موجودی کل
    }

}
