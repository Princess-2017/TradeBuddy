using System;

namespace TradeBuddy.Business.Domain.ValueObjects
{
    public class BusinessName : IEquatable<BusinessName>
    {
        public string Name { get; private set; }

        public BusinessName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Business name cannot be empty");

            Name = name;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as BusinessName);
        }

        public bool Equals(BusinessName other)
        {
            return other != null && Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
