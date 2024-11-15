using System;

namespace TradeBuddy.Business.Domain.Entities
{
    public class BusinessType : BaseEntity<Guid>
    {
        public string Type { get; private set; } // Business type

        protected BusinessType() { } // Parameterless constructor for EF

        public BusinessType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Business type cannot be empty");

            Type = type;
        }

        public override bool Equals(object obj)
        {
            return obj is BusinessType businessType && Id.Equals(businessType.Id);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
