using System;

namespace TradeBuddy.Auth.Domain.ValueObjects
{
    public class UserRoleId : IEquatable<UserRoleId>
    {
        public Guid Value { get; private set; }

        public UserRoleId(Guid value)
        {
            if (value == Guid.Empty)
                throw new ArgumentException("UserRoleId cannot be empty.", nameof(value));

            Value = value;
        }

        // Static method to create new UserRoleId
        public static UserRoleId New() => new UserRoleId(Guid.NewGuid());

        // Equality checks
        public bool Equals(UserRoleId other)
        {
            if (other is null)
                return false;

            return Value == other.Value;
        }

        public override bool Equals(object obj) => Equals(obj as UserRoleId);

        public override int GetHashCode() => Value.GetHashCode();

        public override string ToString() => Value.ToString();
        private UserRoleId() { }
    }
}
