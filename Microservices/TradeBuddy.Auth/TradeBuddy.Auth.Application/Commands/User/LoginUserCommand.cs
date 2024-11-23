using MediatR;

namespace TradeBuddy.Auth.Application.Commands.User
{
    public class LoginUserCommand : IRequest<string>
    {
        // Properties required for login
        public string Username { get; set; }
        public string Password { get; set; }

        // Constructor for easy instantiation
        public LoginUserCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
