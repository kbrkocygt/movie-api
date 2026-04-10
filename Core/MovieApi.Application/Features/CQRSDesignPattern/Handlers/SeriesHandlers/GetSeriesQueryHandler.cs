using System;
using MovieApi.Application.Features.CQRSDesignPattern.Results.SeriesResult;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;

public class GetSeriesQueryHandler
{
    private readonly MovieContext _context;
    public GetSeriesQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<List<GetSeriesQueryResult>> Handle()
    {
        var series = _context.Serieses.ToList();
        return series.Select(s => new GetSeriesQueryResult
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
            SeasonCount = s.SeasonCount,
            EpisodeCount = s.EpisodeCount
        }).ToList();
    }
}
