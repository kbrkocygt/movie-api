using System;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.SeriesCommand;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;

public class UpdateSeriesCommandHandler
{
    private readonly MovieContext _context;
    public UpdateSeriesCommandHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task Handle(UpdateSeriesCommand command)
    {
        var value = await _context.Serieses.FindAsync(command.SeriesId);
        value.Title = command.Title;
        value.CoverImageUrl = command.CoverImageUrl;
        value.Description = command.Description;
        value.CreatedYear = command.CreatedYear;
        value.AverageEpisodeDuration = command.AverageEpisodeDuration;
        value.Rating = command.Rating;
        value.FirstAirDate = command.FirstAirDate;
        value.Status = command.Status;
        value.SeasonCount = command.SeasonCount;
        value.EpisodeCount = command.EpisodeCount;
        value.CategoryId = command.CategoryId;



        await _context.SaveChangesAsync();
    }
}
