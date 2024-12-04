using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Store.Domain.Entities
{
    public class ProductVariantFeature : BaseEntity<Guid>
    {
        public Guid StoreId { get; set; }  // شناسه فروشگاه
        public Guid ProductVariantId { get; set; }  // ارجاع به ترکیب محصول
        public Guid FeatureId { get; set; }         // ارجاع به ویژگی (مثلاً رنگ، سایز، جنس)
        public Guid FeatureValueId { get; set; }   // ارجاع به مقدار ویژگی (مثلاً قرمز، لارج، چرم)

        public virtual ProductVariant ProductVariant { get; set; }
        public virtual Feature Feature { get; set; }        // ویژگی (رنگ، سایز، جنس و ...)
        public virtual FeatureValue FeatureValue { get; set; }  // مقدار ویژگی (قرمز، لارج، چرم و ...)
    }

}
