namespace TradeBuddy.Store.Domain.Entities
{
    public class Feature : BaseEntity<Guid>
    {
        public Guid StoreId { get; set; }  // شناسه فروشگاه
        public string Name { get; set; }

        // روابط وابستگی‌ها (ویژگی‌هایی که به این ویژگی وابسته هستند)
        public virtual ICollection<FeatureDependency> Dependencies { get; set; }

        // ویژگی‌هایی که به این ویژگی وابسته هستند
        public virtual ICollection<FeatureDependency> DependentFeatures { get; set; }

        // مقدار ویژگی‌ها
        public virtual ICollection<FeatureValue> FeatureValues { get; set; }
    }
}
