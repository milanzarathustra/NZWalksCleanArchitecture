﻿using MediatR;

namespace NZWalksCleanArch.API.Commands.Walks;

public class DeleteWalkInfoRequest : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteWalkInfoRequest(Guid id)
    {
        Id = id;
    }

}
