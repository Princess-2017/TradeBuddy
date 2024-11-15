using System;

namespace TradeBuddy.Reservation.Domain.ValueObjects
{
    public class ServiceId
    {
        public Guid Value { get; private set; }

        public ServiceId(Guid value)
        {
            Value = value;
        }

        public static implicit operator Guid(ServiceId serviceId) => serviceId.Value;
        public static implicit operator ServiceId(Guid guid) => new ServiceId(guid);
    }
}
