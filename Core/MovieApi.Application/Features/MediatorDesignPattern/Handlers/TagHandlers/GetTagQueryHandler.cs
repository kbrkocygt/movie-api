using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.TagHandlers;

public class GetTagQueryHandler : IRequestHandler<GetTagQuery, List<GetTagQueryResult>>
{
    private readonly MovieContext _context;
    public GetTagQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<List<GetTagQueryResult>> Handle(GetTagQuery request, CancellationToken cancellationToken)
    {
        var tags = await _context.Tags.ToListAsync();
        return tags.Select(t => new GetTagQueryResult
        {
            TagId = t.TagId,
            Title = t.Title
        }).ToList();
    }
}
