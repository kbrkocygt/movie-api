using System;
using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers;

public class GetCastByIdQueryHandler : IRequestHandler<GetCastByIdQuery, GetCastByIdQueryResult>
{
    private readonly MovieContext _context;
    public GetCastByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<GetCastByIdQueryResult> Handle(GetCastByIdQuery request, CancellationToken cancellationToken)
    {
        var cast = await _context.Casts.FindAsync(request.CastId);
        return new GetCastByIdQueryResult
        {
            Name = cast.Name,
            Surname = cast.Surname,
            CastId = cast.CastId,
            ImageUrl = cast.ImageUrl,
            Biography = cast.Biography
        };
    }
}
