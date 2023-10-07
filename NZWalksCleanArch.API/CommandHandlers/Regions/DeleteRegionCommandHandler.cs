using MediatR;
using NZWalksCleanArch.API.Commands.Walks;
using NZWalksCleanArch.DataService.Repositories.Interfaces;

namespace NZWalksCleanArch.API.CommandHandlers.Regions;

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

        await unitOfWork.CompleteAsync();

        return true;
    }
}
