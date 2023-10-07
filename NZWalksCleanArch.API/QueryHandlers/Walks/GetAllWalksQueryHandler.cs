using AutoMapper;
using MediatR;
using NZWalksCleanArch.API.Queries.Walks;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using NZWalksCleanArch.Entities.Dtos.Walks.Responses;

namespace NZWalksCleanArch.API.QueryHandlers.Walks;

public sealed class GetAllWalksQueryHandler : IRequestHandler<GetAllWalksQuery, IEnumerable<WalkDto>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetAllWalksQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<WalkDto>> Handle(GetAllWalksQuery request, CancellationToken cancellationToken)
    {
        var Walks = await unitOfWork.Walk.GetAllAsync(request.Filter);

        return mapper.Map<IEnumerable<WalkDto>>(Walks);
    }
}
