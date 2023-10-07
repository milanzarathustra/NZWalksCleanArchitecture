using MediatR;
using NZWalksCleanArch.Entities.Dtos.Regions.Responses;

namespace NZWalksCleanArch.API.Queries.Regions;

public sealed class GetRegionQuery : IRequest<RegionDto>
{
    public Guid Id { get; }

    public GetRegionQuery(Guid id)
    {
        Id = id;
    }
}
