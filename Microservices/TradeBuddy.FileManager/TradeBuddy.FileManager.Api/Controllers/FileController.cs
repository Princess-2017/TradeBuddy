using Microsoft.AspNetCore.Mvc;
using TradeBuddy.FileManager.Application.Common.Interfaces;
using TradeBuddy.FileManager.Domain.Entities;

namespace TradeBuddy.FileManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FileManagerController : ControllerBase
    {
        private readonly IFileManagerService _fileManagerService;

        public FileManagerController(IFileManagerService fileManagerService)
        {
            _fileManagerService = fileManagerService;
        }

        // Add File
        [HttpPost("Add")]
        public async Task<IActionResult> AddFile([FromForm] string fileName, [FromForm] string mimeType, [FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Invalid file.");

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);
            var fileId = await _fileManagerService.AddFileAsync(fileName, mimeType, memoryStream.ToArray());

            return Ok(new { FileId = fileId });
        }

        // Delete File
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteFile(string id)
        {
            var result = await _fileManagerService.DeleteFileAsync(id);
            if (!result)
                return NotFound("File not found or couldn't be deleted.");

            return Ok("File deleted successfully.");
        }

        // Update File
        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateFile(string id, [FromForm] string newFileName, [FromForm] IFormFile newFile)
        {
            if (newFile == null || newFile.Length == 0)
                return BadRequest("Invalid file.");

            using var memoryStream = new MemoryStream();
            await newFile.CopyToAsync(memoryStream);
            var result = await _fileManagerService.UpdateFileAsync(id, newFileName, memoryStream.ToArray());

            if (!result)
                return NotFound("File not found or couldn't be updated.");

            return Ok("File updated successfully.");
        }

        // Get File By Id
        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetFileById(string id)
        {
            var file = await _fileManagerService.GetFileByIdAsync(id);
            if (file == null)
                return NotFound("File not found.");

            return File(file.Content, file.MimeType, file.FileName);
        }

        // Get All Files
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllFiles()
        {
            var files = await _fileManagerService.GetAllFilesAsync();
            return Ok(files);
        }
    }
}
