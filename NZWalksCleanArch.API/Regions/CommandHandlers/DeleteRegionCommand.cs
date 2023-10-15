using MediatR;
using NZWalksCleanArch.API.Walks.Commands;
using NZWalksCleanArch.DataService.Repositories.Interfaces;

namespace NZWalksCleanArch.API.Regions.CommandHandlers;

public sealed class DeleteRegionCommand : IRequestHandler<DeleteWalkInfoRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteRegionCommand(
        IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteWalkInfoRequest request, CancellationToken cancellationToken)
    {
        var isDeleted = await unitOfWork.Region.DeleteAsync(request.Id, false);

        if (!isDeleted)
            return false;

        return true;
    }
}
