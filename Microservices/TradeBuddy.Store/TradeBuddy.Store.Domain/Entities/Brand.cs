using System.Collections.Generic;
using TradeBuddy.Store.Domain.ValueObjects;

namespace TradeBuddy.Store.Domain.Entities
{
    public class Brand : BaseEntity<BrandId>
    {
        public virtual BrandId Id { get; private set; }
        public virtual BrandName Name { get; private set; }

        private Brand() { }

        public Brand(BrandId id, BrandName name)
        {
            Id = id;
            Name = name;
        }
    }
}