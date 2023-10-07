namespace NZWalksCleanArch.Entities.DbSet;

public class Region : BaseEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? RegionImageUrl { get; set; }
}
