using NZWalksCleanArch.Entities.Dtos.Difficulties.Responses;
using NZWalksCleanArch.Entities.Dtos.Regions.Responses;

namespace NZWalksCleanArch.Entities.Dtos.Walks.Responses;

public class WalkDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double LengthInKm { get; set; }
    public string? WalkImageUrl { get; set; }

    public RegionDto Region { get; set; } = new();
    public DifficultyDto Difficulty { get; set; } = new();
}
