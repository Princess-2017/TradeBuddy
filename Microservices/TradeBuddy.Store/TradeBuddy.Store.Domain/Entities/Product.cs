using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.ValueObjects;

public class Product : BaseEntity<Guid>
{
    public Guid StoreId { get; set; }  // شناسه فروشگاه
    public virtual ProductName Name { get; set; }
    public virtual Price Price { get; set; }
    public Guid? CategoryId { get; set; }
    public Guid BrandId { get;  set; }

    // ارتباط با Category
    public virtual Category Category { get; set; }
    public virtual Brand Brand { get; set; }
    public virtual List<ProductStock> ProductStocks { get; set; }  // ارتباط با موجودی‌ها
    public virtual List<ProductVariant> ProductVariants { get; set; }  // ویژگی‌های محصول
    public virtual List<ProductFeature> ProductFeatures { get; set; }  // ویژگی‌های محصول
}
