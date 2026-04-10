using System;
using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommand;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers;

public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
{
    private readonly MovieContext _context;
    public UpdateCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
    {
        var cast = await _context.Casts.FindAsync(request.CastId);
        cast.Title = request.Title;
        cast.Name = request.Name;
        cast.Surname = request.Surname;
        cast.ImageUrl = request.ImageUrl;
        cast.Biography = request.Biography;
        // cast.Overview = request.Overview;

        await _context.SaveChangesAsync(cancellationToken);



    }
}
