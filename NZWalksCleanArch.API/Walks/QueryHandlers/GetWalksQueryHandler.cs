using AutoMapper;
using MediatR;
using NZWalksCleanArch.API.Walks.Queries;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using NZWalksCleanArch.Entities.Dtos.Walks.Responses;

namespace NZWalksCleanArch.API.Walks.QueryHandlers;

public sealed class GetWalkQueryHandler : IRequestHandler<GetWalkQuery, WalkDto>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetWalkQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<WalkDto> Handle(GetWalkQuery request, CancellationToken cancellationToken)
    {
        var Walk = await unitOfWork.Walk.GetByIdAsync(request.Id);

        return Walk == null ? new WalkDto { } : mapper.Map<WalkDto>(Walk);
    }
}
