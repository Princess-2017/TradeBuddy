using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Store.Domain.Entities
{
    public class Store : BaseEntity<Guid>
    {
        public Guid BranchId { get; set; }  // شناسه شعبه از Business Service
        public string Name { get; set; }  // نام فروشگاه
    }
}
