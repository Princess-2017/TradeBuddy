using System;

namespace TradeBuddy.Business.Domain.ValueObjects
{
    public class ServiceType : IEquatable<ServiceType>
    {
        public string Type { get; private set; }

        public ServiceType(string type)
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Service type cannot be empty", nameof(type));

            Type = type;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ServiceType);
        }

        public bool Equals(ServiceType other)
        {
            return other != null && Type == other.Type;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type);
        }

        public static bool operator ==(ServiceType left, ServiceType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ServiceType left, ServiceType right)
        {
            return !Equals(left, right);
        }
    }
}
