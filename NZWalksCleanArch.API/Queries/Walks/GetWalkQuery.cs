using MediatR;
using NZWalksCleanArch.Entities.Dtos.Walks.Responses;

namespace NZWalksCleanArch.API.Queries.Walks
{
    public sealed class GetWalkQuery : IRequest<WalkDto>
    {
        public Guid Id { get; }

        public GetWalkQuery(Guid id)
        {
            Id = id;
        }
    }
}
