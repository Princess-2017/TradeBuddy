using MediatR;

namespace TradeBuddy.Auth.Application.Commands.User
{
    public class RegisterUserCommand : IRequest<bool>
    {
        // Properties required for user registration
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // Constructor for ease of instantiation
        public RegisterUserCommand(
            string username,
            string password,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address)
        {
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
        }
    }
}
