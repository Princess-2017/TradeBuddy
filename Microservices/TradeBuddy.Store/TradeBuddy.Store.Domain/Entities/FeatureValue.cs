namespace TradeBuddy.Store.Domain.Entities
{
    public class FeatureValue : BaseEntity<Guid>
    {
        public Guid FeatureId { get; set; }  // ارجاع به ویژگی اصلی
        public string Value { get; set; }  // مقدار ویژگی (مثل "قرمز" یا "لارج")

        // رابطه با Feature (ویژگی)
        public virtual Feature Feature { get; set; }

        // رابطه با ProductFeature (ارتباط دوطرفه)
        public virtual ICollection<ProductFeature> ProductFeatures { get; set; } = new List<ProductFeature>();
    }
}
