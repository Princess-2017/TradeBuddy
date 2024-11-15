public class Address
{
    public string Location { get; private set; }

    public Address(string location)
    {
        if (string.IsNullOrWhiteSpace(location))
        {
            throw new ArgumentException("Address cannot be empty.", nameof(location));
        }

        Location = location;
    }

    public override string ToString()
    {
        return Location;
    }
}
