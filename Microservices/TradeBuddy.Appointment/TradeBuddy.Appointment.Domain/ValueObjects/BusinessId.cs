namespace TradeBuddy.Appointment.Domain.ValueObjects
{
    public class BusinessId
    {
        public Guid Value { get; }

        public BusinessId(Guid value)
        {
            Value = value;
        }

        public override bool Equals(object obj)
        {
            return obj is BusinessId other && Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        private BusinessId() { }

    }

}
