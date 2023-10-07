using MediatR;

namespace NZWalksCleanArch.API.Commands.Regions;

public sealed class DeleteRegionInfoRequest : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteRegionInfoRequest(Guid id)
    {
        Id = id;
    }

}
