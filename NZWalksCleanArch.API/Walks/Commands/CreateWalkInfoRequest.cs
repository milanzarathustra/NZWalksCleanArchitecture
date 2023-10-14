using MediatR;
using NZWalksCleanArch.Entities.Dtos.Walks.Requests;
using NZWalksCleanArch.Entities.Dtos.Walks.Responses;

namespace NZWalksCleanArch.API.Walks.Commands;

public sealed class CreateWalkInfoRequest : IRequest<WalkDto>
{
    public CreateWalkRequest WalkRequest { get; }

    public CreateWalkInfoRequest(CreateWalkRequest walkRequest)
    {
        WalkRequest = walkRequest;
    }
}
