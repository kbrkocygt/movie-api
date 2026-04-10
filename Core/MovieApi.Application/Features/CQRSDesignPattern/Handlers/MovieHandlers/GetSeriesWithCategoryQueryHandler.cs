using System;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.SeriesResult;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class GetSeriesWithCategoryQueryHandler
{
    private readonly MovieContext _context;
    public GetSeriesWithCategoryQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<List<GetSeriesWithCategoryQueryResult>> Handle()
    {
        var series = _context.Serieses.Include(s => s.Category).ToList();
        return series.Select(s => new GetSeriesWithCategoryQueryResult
        {
            SeriesId = s.SeriesId,
            Title = s.Title,
            Description = s.Description,
            CoverImageUrl = s.CoverImageUrl,
            FirstAirDate = s.FirstAirDate,
            Rating = s.Rating,
            AverageEpisodeDuration = s.AverageEpisodeDuration,
            Status = s.Status,
            CreatedYear = s.CreatedYear,
            CategoryId = s.CategoryId,
            CategoryName = s.Category.CategoryName
        }).ToList();
    }

}
