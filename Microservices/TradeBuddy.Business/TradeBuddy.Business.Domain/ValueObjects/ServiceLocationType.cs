using System;

namespace TradeBuddy.Business.Domain.ValueObjects
{
    public class ServiceLocationType : IEquatable<ServiceLocationType>
    {
        public string LocationType { get; private set; }

        public ServiceLocationType(string locationType)
        {
            if (string.IsNullOrWhiteSpace(locationType))
                throw new ArgumentException("Service location type cannot be empty");

            LocationType = locationType;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ServiceLocationType);
        }

        public bool Equals(ServiceLocationType other)
        {
            return other != null && LocationType == other.LocationType;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(LocationType);
        }
    }
}
