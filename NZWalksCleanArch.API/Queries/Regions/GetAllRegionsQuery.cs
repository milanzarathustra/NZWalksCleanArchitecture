using MediatR;
using NZWalksCleanArch.Entities.Dtos.Regions.Responses;
using NZWalksCleanArch.Entities.Models;

namespace NZWalksCleanArch.API.Queries.Regions
{
    public class GetAllRegionsQuery : IRequest<IEnumerable<RegionDto>>
    {
        public Filter Filter { get; }

        public GetAllRegionsQuery(Filter filter)
        {
            Filter = filter;
        }
    }
}
