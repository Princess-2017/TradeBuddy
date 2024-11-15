using TradeBuddy.Payment.Domain.ValueObjects;

namespace TradeBuddy.Payment.Domain.Entities
{
    public class Wallet : BaseEntity<WalletId>
    {
        public WalletId Id { get; private set; }
        public UserId UserId { get; private set; }
        public Amount Balance { get; private set; }

        public Wallet(WalletId id, UserId userId)
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
