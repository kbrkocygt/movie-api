using System;
using MovieApi.Application.Features.CQRSDesignPattern.Results.CategoryResults;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class GetMovieQueryHandler
{
    private readonly MovieContext _context;
    public GetMovieQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<List<GetMovieQueryResult>> Handle()
    {
        var movies = _context.Movies.ToList();
        return movies.Select(m => new GetMovieQueryResult
        {
            MovieId = m.MovieId,
            Title = m.Title,
            Description = m.Description,
            CoverImageUrl = m.CoverImageUrl,
            ReleaseDate = m.ReleaseDate,
            Rating = m.Rating,
            Duration = m.Duration,
            Status = m.Status,
            CreatedYear = m.CreatedYear
        }).ToList();
    }
}
