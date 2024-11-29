using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeBuddy.FileManager.Application.Common.Interfaces;
using TradeBuddy.FileManager.Infrastructure.Context;

namespace TradeBuddy.FileManager.Application.Services
{
    public class FileManagerService:IFileManagerService
    {
        private readonly IMongoCollection<TradeBuddy.FileManager.Domain.Entities.File> _fileCollection;

        public FileManagerService(FileManagerDbContext dbContext)
        {
            _fileCollection = dbContext.Files;
        }

        // افزودن فایل
        public async Task<string> AddFileAsync(string fileName, string mimeType, byte[] content)
        {
            var file = new TradeBuddy.FileManager.Domain.Entities.File
            {
                Id = Guid.NewGuid().ToString(),
                FileName = fileName,
                MimeType = mimeType,
                Content = content,
                Size = content.Length,
                CreatedAt = DateTime.UtcNow
            };

            await _fileCollection.InsertOneAsync(file);
            return file.Id; // بازگرداندن شناسه فایل
        }

        // حذف فایل
        public async Task<bool> DeleteFileAsync(string id)
        {
            var result = await _fileCollection.DeleteOneAsync(f => f.Id == id);
            return result.DeletedCount > 0;
        }

        // ویرایش فایل
        public async Task<bool> UpdateFileAsync(string id, string newFileName, byte[] newContent)
        {
            var update = Builders<TradeBuddy.FileManager.Domain.Entities.File>.Update
                .Set(f => f.FileName, newFileName)
                .Set(f => f.Content, newContent)
                .Set(f => f.Size, newContent.Length)
                .Set(f => f.UploadedAt, DateTime.UtcNow);

            var result = await _fileCollection.UpdateOneAsync(f => f.Id == id, update);
            return result.ModifiedCount > 0;
        }

        // دریافت فایل بر اساس ID
        public async Task<TradeBuddy.FileManager.Domain.Entities.File> GetFileByIdAsync(string id)
        {
            return await _fileCollection.Find(f => f.Id == id).FirstOrDefaultAsync();
        }

        // دریافت لیست فایل‌ها
        public async Task<List<TradeBuddy.FileManager.Domain.Entities.File>> GetAllFilesAsync()
        {
            return await _fileCollection.Find(_ => true).ToListAsync();
        }
    }
}
