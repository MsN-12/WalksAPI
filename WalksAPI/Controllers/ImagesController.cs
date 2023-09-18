using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Writers;
using System.Runtime.CompilerServices;
using WalksAPI.Models.Domain;
using WalksAPI.Models.DTO;
using WalksAPI.Repositories;

namespace WalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromBody] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);
            if(ModelState.IsValid)
            {
                var imageDomainModel = new Image
                {
                    File = request.File,
                    FileExtention = Path.GetExtension(request.File.FileName),
                    FileSizeInBytes = request.File.Length,
                    FileName = request.FileName,
                    FileDescription = request.FileDescription,

                };
                await imageRepository.Upload(imageDomainModel);

                return Ok(imageDomainModel);
            }
            return BadRequest();
        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtentions = new string[] {".jpg", ".jpeg", ".png" };

            if(!allowedExtentions.Contains(Path.GetExtension(request.FileName))) 
            {
                ModelState.AddModelError("file", "Unsupported file extention");
            }
            if(request.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File siza is more than 10MB, please upload smaller size file");
            }
        }
    }
}
