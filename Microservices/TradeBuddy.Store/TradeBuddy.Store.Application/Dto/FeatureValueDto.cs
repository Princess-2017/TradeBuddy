using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Store.Application.Dto
{
    public class FeatureValueDto
    {
        public Guid Id { get; set; }
        public Guid FeatureId { get; set; }  // ارجاع به ویژگی اصلی
        public string Value { get; set; }  // مقدار ویژگی (مثل "قرمز" یا "لارج")
    }
}
