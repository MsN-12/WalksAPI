using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WalksAPI.Models.Domain;
using WalksAPI.Models.DTO;
using WalksAPI.Repositories;

namespace WalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksContorller : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksContorller(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        public async Task<IActionResult> Create([FromBody] AddWalksRequestDto addWalksRequestDto)
        {
            var walkDomainModel = mapper.Map<Walk>(addWalksRequestDto);
            await walkRepository.CreateAsyc(walkDomainModel);

            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }
    }
}
