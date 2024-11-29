namespace TradeBuddy.Store.Domain.Entities
{
    public class FeatureDependency : BaseEntity<Guid>
    {
        public Guid FeatureId { get; private set; } // شناسه ویژگی اصلی
        public Guid DependentFeatureId { get; private set; } // شناسه ویژگی وابسته

        // ارتباط با Feature اصلی
        public virtual Feature Feature { get; private set; }

        // ارتباط با Feature وابسته
        public virtual Feature DependentFeature { get; private set; }
    }
}
