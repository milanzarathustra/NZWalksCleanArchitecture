using MediatR;

namespace NZWalksCleanArch.API.Walks.Commands;

public sealed class DeleteWalkInfoRequest : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteWalkInfoRequest(Guid id)
    {
        Id = id;
    }

}
