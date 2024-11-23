using System;

namespace TradeBuddy.Business.Domain.Entities
{
    public class Media : BaseEntity<Guid>
    {
        public string FileName { get; private set; } // نام فایل
        public string FileUrl { get; private set; } // آدرس دسترسی به فایل
        public string MimeType { get; private set; } // نوع فایل (مثلاً image/jpeg یا video/mp4)
        public long FileSize { get; private set; } // اندازه فایل به بایت
        public Guid BusinessId { get; private set; } // شناسه کسب‌وکار مرتبط

        public virtual Business Business { get; private set; } // ارتباط با کسب‌وکار

        public DateTime UploadedAt { get; private set; } // تاریخ بارگذاری

        // Constructor
        public Media(string fileName, string fileUrl, string mimeType, long fileSize, Guid businessId)
        {
            Id = Guid.NewGuid();
            FileName = fileName;
            FileUrl = fileUrl;
            MimeType = mimeType;
            FileSize = fileSize;
            BusinessId = businessId;
            UploadedAt = DateTime.UtcNow;
        }

        // Parameterless Constructor for EF
        public Media() { }
    }
}
