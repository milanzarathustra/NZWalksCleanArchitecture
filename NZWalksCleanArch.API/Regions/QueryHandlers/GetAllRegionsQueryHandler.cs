using AutoMapper;
using MediatR;
using NZWalksCleanArch.API.Regions.Queries;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using NZWalksCleanArch.Entities.Dtos.Regions.Responses;

namespace NZWalksCleanArch.API.Regions.QueryHandlers;

public sealed class GetAllRegionsQueryHandler : IRequestHandler<GetAllRegionsQuery, IEnumerable<RegionDto>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetAllRegionsQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<IEnumerable<RegionDto>> Handle(GetAllRegionsQuery request, CancellationToken cancellationToken)
    {
        var regions = await unitOfWork.Region.GetAllAsync(request.Filter);

        return mapper.Map<IEnumerable<RegionDto>>(regions);
    }
}
