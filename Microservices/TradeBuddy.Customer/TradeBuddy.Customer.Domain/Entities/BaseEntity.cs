using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.Customer.Domain.Entities
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public string CreateBy { get; protected set; }
        public DateTime? UpdateDate { get; protected set; }
        public string UpdateBy { get; protected set; }
        public bool IsDeleted { get; protected set; }
        public DateTime? DeleteDate { get; protected set; }
        public string DeleteBy { get; protected set; }

        protected BaseEntity()
        {
            CreateDate = DateTime.UtcNow;
            IsDeleted = false;
        }

        public void MarkAsDeleted(string deletedBy)
        {
            IsDeleted = true;
            DeleteDate = DateTime.UtcNow;
            DeleteBy = deletedBy;
        }

        public void Update(string updatedBy)
        {
            UpdateBy = updatedBy;
            UpdateDate = DateTime.UtcNow;
        }
    }

}
