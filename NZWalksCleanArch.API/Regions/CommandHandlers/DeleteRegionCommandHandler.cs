using MediatR;
using NZWalksCleanArch.API.Walks.Commands;
using NZWalksCleanArch.DataService.Repositories.Interfaces;

namespace NZWalksCleanArch.API.Regions.CommandHandlers;

public sealed class DeleteRegionCommandHandler : IRequestHandler<DeleteWalkInfoRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteRegionCommandHandler(
        IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteWalkInfoRequest request, CancellationToken cancellationToken)
    {
        var isDeleted = await unitOfWork.Region.DeleteAsync(request.Id);

        if (!isDeleted)
            return false;

        await unitOfWork.CompleteAsync(cancellationToken);

        return true;
    }
}
