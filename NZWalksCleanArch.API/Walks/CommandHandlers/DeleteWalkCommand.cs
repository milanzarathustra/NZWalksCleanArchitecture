using MediatR;
using NZWalksCleanArch.API.Walks.Commands;
using NZWalksCleanArch.DataService.Repositories.Interfaces;

namespace NZWalksCleanArch.API.Walks.CommandHandlers;

public sealed class DeleteWalkCommand : IRequestHandler<DeleteWalkInfoRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteWalkCommand(
        IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteWalkInfoRequest request, CancellationToken cancellationToken)
    {
        var isDeleted = await unitOfWork.Walk.DeleteAsync(request.Id, false);

        if (!isDeleted)
            return false;

        await unitOfWork.CompleteAsync(cancellationToken);

        return true;
    }
}
