using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalksAPI.Models.Domain;

namespace WalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var region = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Lamerd Region",
                    Code = "Lmd",
                    RegionImgUrl = "https://images.pexels.com/photos/39853/woman-girl-freedom-happy-39853.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Shiraz Region",
                    Code = "Shz",
                    RegionImgUrl = "https://images.pexels.com/photos/39853/woman-girl-freedom-happy-39853.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                }
            };
            return Ok(region);
        }
    }
}
