using AutoMapper;
using MediatR;
using NZWalksCleanArch.API.Commands.Regions;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using NZWalksCleanArch.Entities.DbSet;

namespace NZWalksCleanArch.API.CommandHandlers.Regions;

public sealed class UpdateRegionCommandHandler : IRequestHandler<UpdateRegionInfoRequest, bool>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public UpdateRegionCommandHandler(
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
        await unitOfWork.CompleteAsync();

        return true;
    }
}
