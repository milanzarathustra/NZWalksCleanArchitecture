using AutoMapper;
using MediatR;
using NZWalksCleanArch.API.Regions.Commands;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using NZWalksCleanArch.Entities.DbSet;
using NZWalksCleanArch.Entities.Dtos.Regions.Responses;

namespace NZWalksCleanArch.API.Regions.CommandHandlers;

public sealed class CreateRegionCommand : IRequestHandler<CreateRegionInfoRequest, RegionDto>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreateRegionCommand(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<RegionDto> Handle(CreateRegionInfoRequest request, CancellationToken cancellationToken)
    {
        var region = mapper.Map<Region>(request.RegionRequest);

        await unitOfWork.Region.CreateAsync(region);

        return mapper.Map<RegionDto>(region);
    }
}
