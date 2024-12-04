
namespace TradeBuddy.Business.Domain.Entities
{
    public class Branch : BaseEntity<Guid>
    {
        public Guid BusinessId { get; set; }  // شناسه کسب‌وکار
        public string Name { get; set; }  // نام شعبه
        public virtual Business Business { get; set; }
    }
}
