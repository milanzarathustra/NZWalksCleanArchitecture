using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NZWalksCleanArch.DataService.Data;
using NZWalksCleanArch.DataService.Enums;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using NZWalksCleanArch.Entities.DbSet;
using NZWalksCleanArch.Entities.Models;

namespace NZWalksCleanArch.DataService.Repositories;

public sealed class WalkRepository : GenericRepository<Walk>, IWalkRepository 
{
    public WalkRepository(AppDbContext context, ILogger logger) : base(context, logger)
    {
    }

    public override async Task<IEnumerable<Walk>?> GetAllAsync(Filter filter)
    {
        var walks = context.Walks.Include(x => x.Difficulty).Include(x => x.Region).Where(o => o.Status != (int)Status.Deleted).AsQueryable();

        //Filtering
        if (!string.IsNullOrWhiteSpace(filter.FilterOn) && 
            !string.IsNullOrWhiteSpace(filter.FilterQuery) &&
            filter.FilterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
        {
            walks = walks.Where(x => x.Name.Contains(filter.FilterQuery));
        }

        //Sorting
        if (!string.IsNullOrWhiteSpace(filter.SortBy))
        {
            if (filter.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                walks = filter.IsAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
            }
            else if (filter.SortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
            {
                walks = filter.IsAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
            }
        }

        //Pagination
        var skipPages = (filter.PageNumber - 1) * filter.PageSize;

        return await walks.Skip(skipPages).Take(filter.PageSize).ToListAsync();
    }

    public override async Task<Walk?> GetByIdAsync(Guid id)
    {
        return await context.Walks.Include(x => x.Difficulty).Include(x => x.Region).FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task<bool> UpdateAsync(Guid id, Walk entity)
    {
        var existingWalk = await GetByIdAsync(id);

        if (existingWalk == null)
            return false;

        existingWalk.Name = entity.Name;
        existingWalk.Description = entity.Description;
        existingWalk.LengthInKm = entity.LengthInKm;
        existingWalk.WalkImageUrl = entity.WalkImageUrl;
        existingWalk.DifficultyId = entity.DifficultyId;
        existingWalk.RegionId = entity.RegionId;

        existingWalk.UpdatedDate = DateTime.UtcNow;

        return true;
    }

    public override async Task<bool> DeleteAsync(Guid id, bool shadowDelete = true)
    {
        var existingWalk = await GetByIdAsync(id);

        if (existingWalk == null) 
            return false;

        if (shadowDelete)
        {
            existingWalk.Status = (int)Status.Deleted;
            existingWalk.UpdatedDate = DateTime.UtcNow;
        }
        else
        {
            context.Walks.Remove(existingWalk);
        }

        return true;
    }
}
