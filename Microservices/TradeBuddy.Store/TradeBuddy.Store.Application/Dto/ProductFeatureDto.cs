using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Store.Application.Dto
{
    public class ProductFeatureDto
    {
        public Guid Id { get; set; } // شناسه ProductFeature
        public Guid ProductId { get; set; } // شناسه محصول
        public string ProductName { get; set; } // نام محصول
        public Guid FeatureId { get; set; } // شناسه ویژگی
        public string FeatureName { get; set; } // نام ویژگی
        public Guid FeatureValueId { get; set; } // شناسه مقدار ویژگی
        public string FeatureValue { get; set; } // مقدار ویژگی
    }
}