using Microsoft.AspNetCore.Http;

namespace ETicaretAPI.Application.Services
{
    public interface IFileService
    {
        Task<List<(string fileName, string filePath)>> UploadAsync(string filePath, IFormFileCollection files);
        Task<string> FileRenameAsync(string fileName);
        Task<bool> CopyFileAsync(string filePath, IFormFile file);
    }
}
