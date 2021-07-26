using Core.Application.Dtos;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.File
{
    public interface IFileService
    {
        Task<string> SaveFile(IFormFile File);
        void DeleteFile(string PicturePath);
    }
}
