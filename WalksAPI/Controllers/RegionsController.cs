using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Globalization;
using System.Linq.Expressions;
using WalksAPI.Data;
using WalksAPI.Models.Domain;
using WalksAPI.Models.DTO;

namespace WalksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly DataBaseContext dbContext;
        public RegionsController(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var regions = await dbContext.regions.ToListAsync();

            var regionsDto = new List<RegionDto>();
            foreach (var region in regions)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImgUrl = region.RegionImgUrl,
                });
            }

            return Ok(regionsDto);
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult>GetById([FromRoute]Guid id) 
        {
            var region = await dbContext.regions.FirstOrDefaultAsync(r => r.Id == id);
            if (region == null)
            {
                return NotFound();
            }
            var regionsDto = new RegionDto()
            {
                Id = region.Id,
                Name = region.Name,
                Code = region.Code,
                RegionImgUrl = region.RegionImgUrl,
            };
            return Ok(regionsDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto add)
        {
            var regionDomainModel = new Region
            {
                Code = add.Code,
                Name = add.Name,
                RegionImgUrl = add.RegionImgUrl,
            };
            await dbContext.regions.AddAsync(regionDomainModel);
            await dbContext.SaveChangesAsync();

            var regionDto = new RegionDto()
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
            };
            return CreatedAtAction(nameof(GetById), new {id = regionDto.Id}, regionDto);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto update)
        {
            var regionDomainModel = await dbContext.regions.FirstOrDefaultAsync(r => r.Id == id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            regionDomainModel.Name = update.Name;
            regionDomainModel.Code = update.Code;
            regionDomainModel.RegionImgUrl = update.RegionImgUrl;
            await dbContext.SaveChangesAsync();

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImgUrl = regionDomainModel.RegionImgUrl,
            };
            return Ok(regionDto);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await dbContext.regions.FirstOrDefaultAsync(r => r.Id == id);
            if(regionDomainModel == null) 
            {
                return NotFound(); 
            }
            dbContext.regions.Remove(regionDomainModel);
            await dbContext.SaveChangesAsync();

            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Name = regionDomainModel.Name,
                Code = regionDomainModel.Code,
                RegionImgUrl = regionDomainModel.RegionImgUrl,
            };
            return Ok(regionDto);

        }
    }
}
