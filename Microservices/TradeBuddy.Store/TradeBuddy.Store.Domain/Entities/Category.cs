using TradeBuddy.Store.Domain.ValueObjects;

namespace TradeBuddy.Store.Domain.Entities
{
    public class Category : BaseEntity<CategoryId>
    {
        public virtual CategoryId Id { get; private set; }
        public virtual CategoryName Name { get; private set; }
        public virtual List<Product> Products { get; private set; } // ویژگی ناوبری مجازی
        private Category() { }

        public Category(CategoryId id, CategoryName name)
        {
            Id = id;
            Name = name;
            Products = new List<Product>();
        }
    }

}
