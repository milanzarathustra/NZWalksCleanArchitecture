using MediatR;
using NZWalksCleanArch.Entities.Dtos.Regions.Requests;
using NZWalksCleanArch.Entities.Dtos.Regions.Responses;

namespace NZWalksCleanArch.API.Regions.Commands;

public sealed class CreateRegionInfoRequest : IRequest<RegionDto>
{
    public CreateRegionRequest RegionRequest { get; }

    public CreateRegionInfoRequest(CreateRegionRequest regionRequest)
    {
        RegionRequest = regionRequest;
    }

}
