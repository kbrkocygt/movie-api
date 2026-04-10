using System;
using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommand;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers;

public class CreateCastCommandHandler : IRequestHandler<CreateCastCommand>
{
    private readonly MovieContext _context;

    public CreateCastCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateCastCommand request, CancellationToken cancellationToken)
    {
        _context.Casts.Add(new Cast
        {
            Title = request.Title,
            Name = request.Name,
            Surname = request.Surname,
            ImageUrl = request.ImageUrl,
            Biography = request.Biography
        });
        await _context.SaveChangesAsync(cancellationToken);
    }
}
