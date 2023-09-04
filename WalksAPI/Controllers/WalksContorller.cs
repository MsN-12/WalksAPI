using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalksAPI.Models.Domain;
using WalksAPI.Models.DTO;

namespace WalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksContorller : ControllerBase
    {
        private readonly IMapper mapper;
        public WalksContorller(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDto addWalksRequestDto)
        {
            var walkDomainModel = mapper.Map<Walk>(addWalksRequestDto)
        }
    }
}
