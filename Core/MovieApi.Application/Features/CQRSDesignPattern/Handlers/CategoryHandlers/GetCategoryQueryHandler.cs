using System;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

public class GetCategoryQueryHandler
{
    private readonly MovieContext _context;
    public GetCategoryQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<List<GetCategoryQueryResult>> Handle()
    {
        var categories = await _context.Categories.ToListAsync();
        var results = new List<GetCategoryQueryResult>();
        return categories.Select(c => new GetCategoryQueryResult
        {
            CategoryId = c.CategoryId,
            CategoryName = c.CategoryName,

        }).ToList();
    }
}
