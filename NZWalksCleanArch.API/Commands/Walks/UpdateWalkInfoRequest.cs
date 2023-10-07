using MediatR;
using NZWalksCleanArch.Entities.Dtos.Walks.Requests;

namespace NZWalksCleanArch.API.Commands.Walks;

public sealed class UpdateWalkInfoRequest : IRequest<bool>
{
    public Guid Id { get; }
    public UpdateWalkRequest WalkRequest { get; }

    public UpdateWalkInfoRequest(Guid id, UpdateWalkRequest walkRequest)
    {
        Id = id;
        WalkRequest = walkRequest;
    }
}
