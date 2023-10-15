using AutoMapper;
using MediatR;
using NZWalksCleanArch.API.Regions.Commands;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using NZWalksCleanArch.Entities.DbSet;

namespace NZWalksCleanArch.API.Regions.CommandHandlers;

public sealed class UpdateRegionCommand : IRequestHandler<UpdateRegionInfoRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateRegionCommand(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<bool> Handle(UpdateRegionInfoRequest request, CancellationToken cancellationToken)
    {
        var region = mapper.Map<Region>(request.RegionRequest);

        await unitOfWork.Region.UpdateAsync(request.Id, region);

        return true;
    }
}
