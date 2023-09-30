using MediatR;
using NZWalksCleanArch.Entities.Dtos.Walks.Responses;

namespace NZWalksCleanArch.API.Queries.Walks
{
    public class GetWalkQuery : IRequest<WalkDto>
    {
        public Guid Id { get; }

        public GetWalkQuery(Guid id)
        {
            Id = id;
        }
    }
}
