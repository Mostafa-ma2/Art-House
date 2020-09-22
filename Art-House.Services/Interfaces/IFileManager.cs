using System.Threading.Tasks;
using Art_House.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Art_House.Services.Interfaces
{
    public interface IFileManager 
    {
        Task<string> UploadImage(IFormFile image, FileManagerType.FileType typeI);
        bool DeleteImage(string imageName, FileManagerType.FileType typeI);
        Task<string> CkUpload(IFormFile image);
    }
}