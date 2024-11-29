using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Payment.Domain.ValueObjects;

namespace TradeBuddy.Payment.Domain.Entities
{
    public class Credit : BaseEntity<Guid>
    {
        public UserId UserId { get; private set; }
        public CreditAmount Amount { get; private set; }

        public Credit(Guid id, UserId userId, CreditAmount initialAmount)
        {
            Id = id;
            UserId = userId;
            Amount = initialAmount;
        }
        public Credit()
        {
        }

        public void AddCredit(CreditAmount amount)
        {
            Amount = Amount.Add(amount);
        }

        public void SubtractCredit(CreditAmount amount)
        {
            Amount = Amount.Subtract(amount);
        }
    }

}
