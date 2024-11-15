using System.Net.Mail;

public class EmailAddress
{
    public string Address { get; private set; }

    public EmailAddress(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || !IsValidEmail(address))
        {
            throw new ArgumentException("Invalid email address.", nameof(address));
        }

        Address = address;
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var mail = new MailAddress(email);
            return mail.Address == email;
        }
        catch
        {
            return false;
        }
    }

    public override string ToString()
    {
        return Address;
    }
}
