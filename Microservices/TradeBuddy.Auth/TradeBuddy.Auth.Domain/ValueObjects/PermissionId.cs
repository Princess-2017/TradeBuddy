using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Auth.Domain.ValueObjects
{
    public record PermissionId
    {
        public Guid Value { get; }

        public PermissionId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("Permission ID cannot be empty", nameof(value));

            Value = value;
        }

        public static implicit operator Guid(PermissionId id) => id.Value;
        public static implicit operator PermissionId(Guid id) => new PermissionId(id);
        private PermissionId() { }
    }
}
