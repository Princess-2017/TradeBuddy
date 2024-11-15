using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Domain.Events
{
    public class UserCreatedEvent
    {
        public Guid UserId { get; }
        public string Username { get; }
        public string Email { get; }
        public DateTime CreatedAt { get; }

        public UserCreatedEvent(Guid userId, string username, string email)
        {
            UserId = userId;
            Username = username;
            Email = email;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
