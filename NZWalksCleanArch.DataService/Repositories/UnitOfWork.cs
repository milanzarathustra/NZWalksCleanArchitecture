using Microsoft.Extensions.Logging;
using NZWalksCleanArch.DataService.Data;
using NZWalksCleanArch.DataService.Repositories.Interfaces;

namespace NZWalksCleanArch.DataService.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly AppDbContext context;

    public IRegionRepository Region { get; }
    public IWalkRepository Walk { get; }

    public UnitOfWork(
        AppDbContext context, 
        ILoggerFactory loggerFactory)
    {
        this.context = context;

        var logger = loggerFactory.CreateLogger("logs");

        Region = new RegionRepository(context, logger);
        Walk = new WalkRepository(context, logger);
    }

    public async Task<bool> CompleteAsync()
    {
        var result = await context.SaveChangesAsync();

        return result > 0;
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
