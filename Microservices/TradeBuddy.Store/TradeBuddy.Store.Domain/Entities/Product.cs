using TradeBuddy.Store.Domain.Entities;
using TradeBuddy.Store.Domain.ValueObjects;

public class Product : BaseEntity<ProductId>
{
    public virtual ProductId Id { get; private set; }
    public virtual ProductName Name { get; private set; }
    public virtual Price Price { get; private set; }
    public virtual CategoryId CategoryId { get; private set; }
    public virtual BrandId BrandId { get; private set; }

    // ارتباط با Category
    public virtual Category Category { get; set; }
}
