using System.Collections.Generic;
using TradeBuddy.Store.Domain.ValueObjects;

namespace TradeBuddy.Store.Domain.Entities
{
    public class Brand : BaseEntity<Guid>
    {
        public virtual BrandName Name { get; private set; }

        private Brand() { }

        public Brand(Guid id, BrandName name)
        {
            Id = id;
            Name = name;
        }
    }
}