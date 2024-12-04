using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Store.Application.Dto
{
    public class ProductVariantFeatureDto
    {
        public Guid FeatureId { get; set; }
        public Guid FeatureValueId { get; set; }
    }
}
