using WalksAPI.Models.Domain;
using WalksAPI.Models.DTO;
using AutoMapper;

namespace WalksAPI.Mappings
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles() 
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddWalksRequestDto, Walk>().ReverseMap();
        } 
    }
}
