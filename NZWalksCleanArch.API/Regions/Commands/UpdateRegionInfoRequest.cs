using MediatR;
using NZWalksCleanArch.Entities.Dtos.Regions.Requests;

namespace NZWalksCleanArch.API.Regions.Commands;

public sealed class UpdateRegionInfoRequest : IRequest<bool>
{
    public Guid Id { get; }
    public UpdateRegionRequest RegionRequest { get; }

    public UpdateRegionInfoRequest(Guid id, UpdateRegionRequest regionRequest)
    {
        Id = id;
        RegionRequest = regionRequest;
    }

}
