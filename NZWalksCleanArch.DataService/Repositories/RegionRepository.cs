using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NZWalksCleanArch.DataService.Data;
using NZWalksCleanArch.DataService.Enums;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using NZWalksCleanArch.Entities.DbSet;
using NZWalksCleanArch.Entities.Models;

namespace NZWalksCleanArch.DataService.Repositories;

public sealed class RegionRepository : GenericRepository<Region>, IRegionRepository
{
    public RegionRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

    public override async Task<IEnumerable<Region>?> GetAllAsync(Filter filter)
    {
        var regions = context.Regions.Where(o => o.Status != (int)Status.Deleted).AsQueryable();

        //Filtering
        if (!string.IsNullOrWhiteSpace(filter.FilterOn) &&
            !string.IsNullOrWhiteSpace(filter.FilterQuery) &&
            filter.FilterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
        {
            regions = regions.Where(x => x.Name.Contains(filter.FilterQuery));
        }

        //Sorting
        if (!string.IsNullOrWhiteSpace(filter.SortBy) &&
            filter.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
        {
            regions = filter.IsAscending ? regions.OrderBy(x => x.Name) : regions.OrderByDescending(x => x.Name);
        }

        //Pagination
        var skipPages = (filter.PageNumber - 1) * filter.PageSize;

        return await regions.Skip(skipPages).Take(filter.PageSize).ToListAsync();
    }

    public override async Task<Region?> GetByIdAsync(Guid id)
    {
        return await context.Regions.FindAsync(id);
    }

    public override async Task<bool> UpdateAsync(Guid id, Region entity)
    {
        var existingRegion = await GetByIdAsync(id);

        if (existingRegion == null) 
            return false;

        existingRegion.Code = entity.Code;
        existingRegion.Name = entity.Name;
        existingRegion.RegionImageUrl = entity.RegionImageUrl;

        existingRegion.UpdatedDate = DateTime.UtcNow;

        return true;
    }

    public override async Task<bool> DeleteAsync(Guid id, bool shadowDelete = true)
    {
        var existingRegion = await GetByIdAsync(id);

        if (existingRegion == null)
            return false;

        if (shadowDelete)
        {
            existingRegion.Status = (int)Status.Deleted;
            existingRegion.UpdatedDate = DateTime.UtcNow;
        }
        else
        {
            context.Regions.Remove(existingRegion);
        }

        return true;
    }
}
