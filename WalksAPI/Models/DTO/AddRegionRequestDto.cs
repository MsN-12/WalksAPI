﻿namespace WalksAPI.Models.DTO
{
    public class AddRegionRequestDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string? RegionImgUrl { get; set; }
    }
}