using MediatR;

namespace NZWalksCleanArch.API.Regions.Commands;

public sealed class DeleteRegionInfoRequest : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteRegionInfoRequest(Guid id)
    {
        Id = id;
    }

}
