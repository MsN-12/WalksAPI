using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetAll()
        {
            var regions = dbContext.regions.ToList();

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
        public IActionResult GetById([FromRoute]Guid id) 
        {
            var region = dbContext.regions.FirstOrDefault(r => r.Id == id);
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
        public IActionResult Create([FromBody] AddRegionRequestDto add)
        {
            var regionDomainModel = new Region
            {
                Code = add.Code,
                Name = add.Name,
                RegionImgUrl = add.RegionImgUrl,
            };
            dbContext.regions.Add(regionDomainModel);
            dbContext.SaveChanges();

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
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto update)
        {
            var regionDomainModel = dbContext.regions.FirstOrDefault(r => r.Id == id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            regionDomainModel.Name = update.Name;
            regionDomainModel.Code = update.Code;
            regionDomainModel.RegionImgUrl = update.RegionImgUrl;
            dbContext.SaveChanges();

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
        public IActionResult Delete([FromRoute] Guid id)
        {
            var regionDomainModel = dbContext.regions.FirstOrDefault(r => r.Id == id);
            if(regionDomainModel == null) 
            {
                return NotFound(); 
            }
            dbContext.regions.Remove(regionDomainModel);
            dbContext.SaveChanges();

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
