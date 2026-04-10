using System;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.SeriesQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.SeriesResult;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;

public class GetSeriesByIdQueryHandler
{
    private readonly MovieContext _context;

    public GetSeriesByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetSeriesByIdQueryResult> Handle(GetSeriesByIdQuery query)
    {
        var series = await _context.Serieses.FindAsync(query.SeriesId);
        return new GetSeriesByIdQueryResult
        {
            SeriesId = series.SeriesId,
            Title = series.Title,
            Description = series.Description,
            CoverImageUrl = series.CoverImageUrl,
            FirstAirDate = series.FirstAirDate,
            Rating = series.Rating,
            AverageEpisodeDuration = series.AverageEpisodeDuration,
            Status = series.Status,
            CreatedYear = series.CreatedYear,
            SeasonCount = series.SeasonCount,
            EpisodeCount = series.EpisodeCount,
            CategoryId = series.CategoryId

        };
    }
}
