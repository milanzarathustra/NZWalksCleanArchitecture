namespace NZWalksCleanArch.DataService.Repositories.Interfaces;

public interface IUnitOfWork
{
    IRegionRepository Region { get; }
    IWalkRepository Walk { get; }

    Task<bool> CompleteAsync(CancellationToken cancellationToken);
}
