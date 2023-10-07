﻿using System.ComponentModel.DataAnnotations;

namespace NZWalksCleanArch.Entities.Dtos.Regions.Requests;

public sealed class UpdateRegionRequest
{
    [Required]
    [MinLength(3, ErrorMessage = "Code has to be a minimum of 3 characters")]
    [MaxLength(3, ErrorMessage = "Code has to be a maximum of 3 characters")]
    public string Code { get; set; } = string.Empty;

    [Required]
    [MaxLength(100, ErrorMessage = "Name can only be a maximum of 100 characters")]
    public string Name { get; set; } = string.Empty;

    public string? RegionImageUrl { get; set; }
}
