﻿using WalksAPI.Models.Domain;

namespace WalksAPI.Models.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImgUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

    }
}