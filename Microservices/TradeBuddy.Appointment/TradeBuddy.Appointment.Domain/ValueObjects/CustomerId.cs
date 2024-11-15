namespace TradeBuddy.Appointment.Domain.ValueObjects
{
    public class CustomerId
    {
        public Guid Value { get; }

        public CustomerId(Guid value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is CustomerId other && Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        private CustomerId() { }
    }

}
