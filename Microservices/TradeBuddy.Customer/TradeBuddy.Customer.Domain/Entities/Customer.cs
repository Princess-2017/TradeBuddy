using System.Net.Mail;
using TradeBuddy.Customer.Domain.ValueObjects;

namespace TradeBuddy.Customer.Domain.Entities
{
    public class Customer : BaseEntity<CustomerId>
    {
        public FullName FullName { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public EmailAddress EmailAddress { get; private set; }
        public Address Address { get; private set; }

        public Customer(CustomerId id, FullName fullName, PhoneNumber phoneNumber, EmailAddress emailAddress, Address address)
        {
            Id = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            Address = address;
        }

        // Methods for business logic like UpdateAddress, UpdatePhoneNumber, etc.
    }
}
