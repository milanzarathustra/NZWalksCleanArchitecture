using MediatR;
using NZWalksCleanArch.Entities.Dtos.Regions.Responses;
using NZWalksCleanArch.Entities.Models;

namespace NZWalksCleanArch.API.Regions.Queries;

public sealed class GetAllRegionsQuery : IRequest<IEnumerable<RegionDto>>
{
    public Filter Filter { get; }

    public GetAllRegionsQuery(Filter filter)
    {
        Filter = filter;
    }
}
