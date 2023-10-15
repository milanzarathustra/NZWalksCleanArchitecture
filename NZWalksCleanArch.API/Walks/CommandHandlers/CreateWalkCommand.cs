using AutoMapper;
using MediatR;
using NZWalksCleanArch.API.Walks.Commands;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using NZWalksCleanArch.Entities.DbSet;
using NZWalksCleanArch.Entities.Dtos.Walks.Responses;

namespace NZWalksCleanArch.API.Walks.CommandHandlers;

public sealed class CreateWalkCommand : IRequestHandler<CreateWalkInfoRequest, WalkDto>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateWalkCommand(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<WalkDto> Handle(CreateWalkInfoRequest request, CancellationToken cancellationToken)
    {
        var walk = mapper.Map<Walk>(request.WalkRequest);

        await unitOfWork.Walk.CreateAsync(walk);
        await unitOfWork.CompleteAsync(cancellationToken);

        return mapper.Map<WalkDto>(walk);
    }
}
