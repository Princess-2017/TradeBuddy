using System;

namespace TradeBuddy.Auth.Domain.ValueObjects
{
    public class RolePermissionId : IEquatable<RolePermissionId>
    {
        public Guid Value { get; private set; }

        public RolePermissionId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("RolePermissionId cannot be empty.", nameof(value));

            Value = value;
        }

        // Static method to create new RolePermissionId
        public static RolePermissionId New() => new RolePermissionId(Guid.NewGuid());

        // Equality checks
        public bool Equals(RolePermissionId other)
        {
            if (other is null)
                return false;

            return Value == other.Value;
        }

        public override bool Equals(object obj) => Equals(obj as RolePermissionId);

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString();

        private RolePermissionId() { }
    }
}
