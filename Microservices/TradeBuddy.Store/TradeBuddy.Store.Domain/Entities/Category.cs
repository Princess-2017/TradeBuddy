using TradeBuddy.Store.Domain.ValueObjects;

namespace TradeBuddy.Store.Domain.Entities
{
    public class Category : BaseEntity<Guid>
    {
        public Guid StoreId { get; set; }  // شناسه فروشگاه
        public virtual CategoryName Name { get; private set; }
        public virtual List<Product> Products { get; private set; } // ویژگی ناوبری برای محصولات
        public virtual Category? ParentCategory { get; private set; } // رابطه والد (اختیاری)
        public Guid? ParentCategoryId { get; set; } // شناسه والد (اختیاری)

        private Category() { }

        // سازنده با پارامترهای ضروری
        public Category(Guid id, CategoryName name, Guid? parentCategoryId = null)
        {
            Id = id;
            Name = name;
            ParentCategoryId = parentCategoryId;
            Products = new List<Product>();
        }
    }
}
