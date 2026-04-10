using System;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.SeriesCommand;
using MovieApi.Domain.Entities;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;

public class CreateSeriesCommandHandler
{

    private readonly MovieContext _context;
    public CreateSeriesCommandHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task Handle(CreateSeriesCommand command)
    {
        _context.Serieses.Add(new Series
        {
            CoverImageUrl = command.CoverImageUrl,
            CreatedYear = command.CreatedYear,
            Description = command.Description,
            AverageEpisodeDuration = command.AverageEpisodeDuration,
            Rating = command.Rating,
            FirstAirDate = command.FirstAirDate,
            Status = command.Status,
            Title = command.Title,
            EpisodeCount = command.EpisodeCount,
            SeasonCount = command.SeasonCount,
            CategoryId = command.CategoryId,

        });
        await _context.SaveChangesAsync();
    }
}
