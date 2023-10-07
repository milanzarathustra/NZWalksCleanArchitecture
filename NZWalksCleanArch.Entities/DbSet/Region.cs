namespace NZWalksCleanArch.Entities.DbSet;

public sealed class Region : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? RegionImageUrl { get; set; }
}
