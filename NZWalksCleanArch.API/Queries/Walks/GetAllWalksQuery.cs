using MediatR;
using NZWalksCleanArch.Entities.Dtos.Walks.Responses;
using NZWalksCleanArch.Entities.Models;

namespace NZWalksCleanArch.API.Queries.Walks;

public class GetAllWalksQuery : IRequest<IEnumerable<WalkDto>>
{
    public Filter Filter { get; }

    public GetAllWalksQuery(Filter filter)
    {
        Filter = filter;
    }
}
