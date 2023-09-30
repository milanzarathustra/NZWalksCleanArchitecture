using MediatR;
using NZWalksCleanArch.Entities.Dtos.Regions.Requests;
using NZWalksCleanArch.Entities.Dtos.Regions.Responses;

namespace NZWalksCleanArch.API.Commands.Regions
{
    public class CreateRegionInfoRequest : IRequest<RegionDto>
    {
        public CreateRegionRequest RegionRequest { get; }

        public CreateRegionInfoRequest(CreateRegionRequest regionRequest)
        {
            RegionRequest = regionRequest;
        }

    }
}
