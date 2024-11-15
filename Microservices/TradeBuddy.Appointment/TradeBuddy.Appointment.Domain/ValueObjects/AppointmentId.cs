public class AppointmentId
{
    public Guid Value { get; }

    public AppointmentId(Guid value)
    {
        Value = value;
    }

    public override bool Equals(object obj)
    {
        return obj is AppointmentId other && Value.Equals(other.Value);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    // Parameterless constructor for EF Core
    private AppointmentId() { }
}
