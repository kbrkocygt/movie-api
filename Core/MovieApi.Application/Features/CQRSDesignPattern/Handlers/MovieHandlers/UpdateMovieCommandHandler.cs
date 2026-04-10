using System;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommand;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class UpdateMovieCommandHandler
{
    private readonly MovieContext _context;
    public UpdateMovieCommandHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task Handle(UpdateMovieCommand command)
    {
        var value = await _context.Movies.FindAsync(command.MovieId);
        value.Title = command.Title;
        value.CoverImageUrl = command.CoverImageUrl;
        value.Description = command.Description;
        value.CreatedYear = command.CreatedYear;
        value.Duration = command.Duration;
        value.Rating = command.Rating;
        value.ReleaseDate = command.ReleaseDate;
        value.Status = command.Status;


        await _context.SaveChangesAsync();
    }
}
