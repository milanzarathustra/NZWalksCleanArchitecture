﻿using AutoMapper;
using MediatR;
using NZWalksCleanArch.API.Walks.Commands;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using NZWalksCleanArch.Entities.DbSet;

namespace NZWalksCleanArch.API.Walks.CommandHandlers;

public sealed class UpdateWalkCommand : IRequestHandler<UpdateWalkInfoRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateWalkCommand(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(UpdateWalkInfoRequest request, CancellationToken cancellationToken)
    {
        var walk = mapper.Map<Walk>(request.WalkRequest);

        await unitOfWork.Walk.UpdateAsync(request.Id, walk);

        return true;
    }
}
