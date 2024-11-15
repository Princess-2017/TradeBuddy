public class FullName
{
    public string Name { get; private set; }

    public FullName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Full name cannot be empty.", nameof(name));
        }

        Name = name;
    }

    public override string ToString()
    {
        return Name;
    }
}
