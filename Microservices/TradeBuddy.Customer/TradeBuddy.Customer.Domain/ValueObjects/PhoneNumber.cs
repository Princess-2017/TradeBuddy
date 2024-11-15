public class PhoneNumber
{
    public string Number { get; private set; }

    public PhoneNumber(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
        {
            throw new ArgumentException("Phone number cannot be empty.", nameof(number));
        }

        Number = number;
    }

    public override string ToString()
    {
        return Number;
    }
}
