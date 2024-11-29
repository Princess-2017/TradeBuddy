using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeBuddy.FileManager.Application.Common.Interfaces
{
    public interface IFileManagerService
    {
        Task<string> AddFileAsync(string fileName, string mimeType, byte[] content);
        Task<bool> DeleteFileAsync(string id);
        Task<bool> UpdateFileAsync(string id, string newFileName, byte[] newContent);
        Task<TradeBuddy.FileManager.Domain.Entities.File> GetFileByIdAsync(string id);
        Task<List<TradeBuddy.FileManager.Domain.Entities.File>> GetAllFilesAsync();
    }
}

