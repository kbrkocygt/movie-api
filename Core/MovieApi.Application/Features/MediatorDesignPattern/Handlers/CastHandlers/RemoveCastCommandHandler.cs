using System;
using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommand;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers;

public class RemoveCastCommandHandler : IRequestHandler<RemoveCastCommand>
{
    private readonly MovieContext _context;
    public RemoveCastCommandHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
    {
        var cast = await _context.Casts.FindAsync(request.CastId);
        _context.Casts.Remove(cast);
        await _context.SaveChangesAsync(cancellationToken);

    }
}
