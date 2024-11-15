using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Domain.ValueObjects
{
    public record RoleId
    {
        public Guid Value { get; }

        public RoleId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("Role ID cannot be empty", nameof(value));

            Value = value;
        }

        public static implicit operator Guid(RoleId id) => id.Value;
        public static implicit operator RoleId(Guid id) => new RoleId(id);
        private RoleId() { }
    }
}
