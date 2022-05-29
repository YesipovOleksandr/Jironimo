using Microsoft.AspNetCore.Http;

namespace Jironimo.Common.Abstract.Services
{
    public interface IImageUploadService
    {
        Task<string> UploadImage(IFormFile formFile, string pathFolder);
        bool DeleteImage(string imagePath, string pathFolder);
    }
}
