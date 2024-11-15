using System;

namespace TradeBuddy.Reservation.Domain.ValueObjects
{
    public class ReservationId
    {
        public Guid Value { get; private set; }

        public ReservationId(Guid value)
        {
            Value = value;
        }

        public override string ToString() => Value.ToString();
    }
}