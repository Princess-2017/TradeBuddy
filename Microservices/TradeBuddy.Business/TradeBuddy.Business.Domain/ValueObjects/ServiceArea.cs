using System;

namespace TradeBuddy.Business.Domain.ValueObjects
{
    public class ServiceArea : IEquatable<ServiceArea>
    {
        public double RadiusInKilometers { get; private set; }
        public string CenterLocation { get; private set; }

        public ServiceArea(double radiusInKilometers, string centerLocation)
        {
            if (radiusInKilometers <= 0)
                throw new ArgumentException("Radius must be greater than zero");

            RadiusInKilometers = radiusInKilometers;
            CenterLocation = centerLocation;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ServiceArea);
        }

        public bool Equals(ServiceArea other)
        {
            return other != null &&
                   RadiusInKilometers == other.RadiusInKilometers &&
                   CenterLocation == other.CenterLocation;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(RadiusInKilometers, CenterLocation);
        }
    }
}
