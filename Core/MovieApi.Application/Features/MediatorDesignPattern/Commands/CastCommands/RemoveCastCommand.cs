using System;
using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommand;

public class RemoveCastCommand : IRequest
{
    public RemoveCastCommand(int castId)
    {
        CastId = castId;
    }

    public int CastId { get; set; }


}
