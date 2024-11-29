using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace TradeBuddy.FileManager.Domain.Entities
{

    public class File
    {
        [BsonId] // MongoDB's unique identifier
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } // شناسه فایل (MongoDB ObjectId)

        [BsonElement("fileName")]
        public string FileName { get; set; } // نام فایل

        [BsonElement("fileUrl")]
        public string FileUrl { get; set; } // آدرس ذخیره فایل
        public string MimeType { get; set; }

        public byte[] Content { get; set; }

        public long Size { get; set; }

        [BsonElement("entityType")]
        public string EntityType { get; set; } // نوع موجودیت مرتبط (مثلاً Service, Product)

        [BsonElement("entityId")]
        public Guid EntityId { get; set; } // شناسه موجودیت مرتبط

        [BsonElement("uploadedAt")]
        public DateTime UploadedAt { get; set; } // تاریخ بارگذاری
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; } // تاریخ بارگذاری

    }
}

