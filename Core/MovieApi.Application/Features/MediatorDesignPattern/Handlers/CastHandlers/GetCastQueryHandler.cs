using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers;

public class GetCastQueryHandler : IRequestHandler<GetCastQuery, List<GetCastQueryResult>>
{
    private readonly MovieContext _context;
    public GetCastQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<List<GetCastQueryResult>> Handle(GetCastQuery request, CancellationToken cancellationToken)
    {
        var casts = await _context.Casts.ToListAsync();
        return casts.Select(c => new GetCastQueryResult
        {

            Name = c.Name,
            Surname = c.Surname,
            CastId = c.CastId,
            ImageUrl = c.ImageUrl,
            Biography = c.Biography
        }).ToList();

    }
}
