using MediatR;
using NZWalksCleanArch.Entities.Dtos.Walks.Requests;
using NZWalksCleanArch.Entities.Dtos.Walks.Responses;

namespace NZWalksCleanArch.API.Commands.Walks
{
    public class CreateWalkInfoRequest : IRequest<WalkDto>
    {
        public CreateWalkRequest WalkRequest { get; }

        public CreateWalkInfoRequest(CreateWalkRequest walkRequest)
        {
            WalkRequest = walkRequest;
        }
    }
}
