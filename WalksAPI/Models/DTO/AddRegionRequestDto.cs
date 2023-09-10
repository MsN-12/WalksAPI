using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WalksAPI.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be maximum of 100 character")]
        public string Name { get; set; }

        [MinLength(3, ErrorMessage = "Code has to be minimum of 3 character")]
        [MaxLength(3, ErrorMessage = "Code has to be maximum of 3 character")]
        [Required]
        public string Code { get; set; }

        public string? RegionImgUrl { get; set; }
    }
}
