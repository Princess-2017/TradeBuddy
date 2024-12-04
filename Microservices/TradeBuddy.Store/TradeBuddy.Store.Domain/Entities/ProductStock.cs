namespace TradeBuddy.Store.Domain.Entities
{
    public class ProductStock : BaseEntity<Guid>
    {
        public Guid StoreId { get; set; }  // شناسه فروشگاه
        public Guid ProductId { get; set; }  // شناسه محصول
        public Guid ProductVariantId { get; set; }  // شناسه ویژگی محصول (مثل رنگ و سایز)
        public int TotalStock { get; set; }  // موجودی کل محصول برای این ویژگی خاص

        // ارتباط با Product (محصول کلی)
        public virtual Product Product { get; set; }

        // ارتباط با ProductVariant (ویژگی‌های خاص محصول مثل رنگ و سایز)
        public virtual ProductVariant ProductVariant { get; set; }
    }
}
