using AutoMapper;
using MediatR;
using NZWalksCleanArch.API.Queries.Regions;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using NZWalksCleanArch.Entities.Dtos.Regions.Responses;

namespace NZWalksCleanArch.API.QueryHandlers.Regions;

public class GetRegionQueryHandler : IRequestHandler<GetRegionQuery, RegionDto>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetRegionQueryHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<RegionDto> Handle(GetRegionQuery request, CancellationToken cancellationToken)
    {
        var region = await unitOfWork.Region.GetByIdAsync(request.Id);

        return region == null ? new RegionDto { } : mapper.Map<RegionDto>(region);
    }
}
