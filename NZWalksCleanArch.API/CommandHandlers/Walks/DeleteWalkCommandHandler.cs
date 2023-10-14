﻿using MediatR;
using NZWalksCleanArch.API.Commands.Walks;
using NZWalksCleanArch.DataService.Repositories.Interfaces;

namespace NZWalksCleanArch.API.CommandHandlers.Walks;

public sealed class DeleteWalkCommandHandler : IRequestHandler<DeleteWalkInfoRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;

    public DeleteWalkCommandHandler(
        IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    public async Task<bool> Handle(DeleteWalkInfoRequest request, CancellationToken cancellationToken)
    {
        var isDeleted = await unitOfWork.Walk.DeleteAsync(request.Id);

        if (!isDeleted)
            return false;

        await unitOfWork.CompleteAsync(cancellationToken);

        return true;
    }
}
