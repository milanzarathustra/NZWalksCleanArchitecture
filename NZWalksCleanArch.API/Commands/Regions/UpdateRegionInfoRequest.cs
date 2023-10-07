using MediatR;
using NZWalksCleanArch.Entities.Dtos.Regions.Requests;

namespace NZWalksCleanArch.API.Commands.Regions;

public class UpdateRegionInfoRequest : IRequest<bool>
{
    public Guid Id { get; }
    public UpdateRegionRequest RegionRequest { get; }

    public UpdateRegionInfoRequest(Guid id, UpdateRegionRequest regionRequest)
    {
        Id = id;
        RegionRequest = regionRequest;
    }

}
