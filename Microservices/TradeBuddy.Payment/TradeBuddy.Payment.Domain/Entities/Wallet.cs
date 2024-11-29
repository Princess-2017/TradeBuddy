using TradeBuddy.Payment.Domain.ValueObjects;

namespace TradeBuddy.Payment.Domain.Entities
{
    public class Wallet : BaseEntity<Guid>
    {
        public Guid Id { get; private set; }
        public UserId UserId { get; private set; }
        public Amount Balance { get; private set; }

        public Wallet(Guid id, UserId userId)
        {
            Id = id;
            UserId = userId;
            Balance = new Amount(0);
        }

        public void Deposit(Amount amount)
        {
            Balance = Balance.Add(amount);
        }

        public void Withdraw(Amount amount)
        {
            Balance = Balance.Subtract(amount);
        }
    }
}
