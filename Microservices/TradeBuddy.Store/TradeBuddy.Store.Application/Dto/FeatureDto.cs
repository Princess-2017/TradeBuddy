namespace TradeBuddy.Store.Application.Dto
{
    public class FeatureDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<DependencyDto> Dependencies { get; set; } = new List<DependencyDto>();
    }

    public class DependencyDto
    {
        public Guid Id { get; set; }         // شناسه وابستگی
        public Guid DependentFeatureId { get; set; } // شناسه ویژگی وابسته
        public string DependentFeatureName { get; set; } // نام ویژگی وابسته
    }
}
