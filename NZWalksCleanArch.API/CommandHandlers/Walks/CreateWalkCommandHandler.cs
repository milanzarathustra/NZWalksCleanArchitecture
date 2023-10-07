using AutoMapper;
using MediatR;
using NZWalksCleanArch.API.Commands.Walks;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using NZWalksCleanArch.Entities.DbSet;
using NZWalksCleanArch.Entities.Dtos.Walks.Responses;

namespace NZWalksCleanArch.API.CommandHandlers.Walks;

public sealed class CreateWalkCommandHandler : IRequestHandler<CreateWalkInfoRequest, WalkDto>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateWalkCommandHandler(
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
        await unitOfWork.CompleteAsync();

        return mapper.Map<WalkDto>(walk);
    }
}
