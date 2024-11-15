using System;

namespace TradeBuddy.Reservation.Domain.ValueObjects
{
    public class BranchId
    {
        public Guid Value { get; private set; }

        public BranchId(Guid value)
        {
            Value = value;
        }

        public static implicit operator Guid(BranchId branchId) => branchId.Value;
        public static implicit operator BranchId(Guid guid) => new BranchId(guid);
    }
}
