using MongoDB.Driver;
using TradeBuddy.FileManager.Domain.Entities;

namespace TradeBuddy.FileManager.Infrastructure.Context
{
    public class FileManagerDbContext
    {
        private readonly IMongoDatabase _database;

        public FileManagerDbContext(IMongoClient mongoClient)
        {
            var databaseName = "FileManagerDb"; // می‌توانید از تنظیمات فایل کانفیگ استفاده کنید
            _database = mongoClient.GetDatabase(databaseName);
        }

        public IMongoCollection<TradeBuddy.FileManager.Domain.Entities.File> Files => _database.GetCollection<TradeBuddy.FileManager.Domain.Entities.File>("Files");

        // در اینجا می‌توانید دیگر مجموعه‌ها و جداول مشابه SQL را اضافه کنید
    }
}
