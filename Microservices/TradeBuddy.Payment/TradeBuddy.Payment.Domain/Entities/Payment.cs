using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.Payment.Domain.ValueObjects;

namespace TradeBuddy.Payment.Domain.Entities
{
    public class Payment : BaseEntity<Guid>
    {
        public Guid Id { get; private set; }
        public Amount Amount { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public TransactionId TransactionId { get; private set; }
        public PaymentStatus Status { get; private set; }
        public DateTime PaymentDate { get; private set; }

        public Payment(Guid id, Amount amount, PaymentMethod paymentMethod, TransactionId transactionId, PaymentStatus status)
        {
            Id = id;
            Amount = amount;
            PaymentMethod = paymentMethod;
            TransactionId = transactionId;
            Status = status;
            PaymentDate = DateTime.UtcNow;
        }

        public void CompletePayment()
        {
            Status = PaymentStatus.Completed;
        }

        public void FailPayment()
        {
            Status = PaymentStatus.Failed;
        }
    }

}
