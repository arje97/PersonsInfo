using Microsoft.AspNetCore.Http;
namespace Core.Application.Dtos
{
    public  class UploadPictureDto
    {
        public int PersonId { get; set; }
        public IFormFile File { get; set; }
       

    }
}
