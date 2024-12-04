namespace TradeBuddy.Store.Domain.Entities
{
    public class ProductFeature : BaseEntity<Guid>
    {
        public Guid StoreId { get; set; }  // شناسه فروشگاه
        public Guid ProductId { get; set; }
        public Guid FeatureValueId { get; set; }  // ارتباط با FeatureValue
        public Guid FeatureId { get; set; }

        // رابطه با Product
        public virtual Product Product { get; set; }

        // رابطه با FeatureValue
        public virtual FeatureValue FeatureValue { get; set; }

        // رابطه با Feature
        public virtual Feature Feature { get; set; }
    }
}
