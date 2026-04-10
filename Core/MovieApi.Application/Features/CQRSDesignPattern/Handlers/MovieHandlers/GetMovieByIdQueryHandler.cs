using System;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class GetMovieByIdQueryHandler
{

    private readonly MovieContext _context;

    public GetMovieByIdQueryHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
    {
        var movie = await _context.Movies.FindAsync(query.MovieId);
        return new GetMovieByIdQueryResult
        {
            MovieId = movie.MovieId,
            Title = movie.Title,
            Description = movie.Description,
            CoverImageUrl = movie.CoverImageUrl,
            ReleaseDate = movie.ReleaseDate,
            Rating = movie.Rating,
            Duration = movie.Duration,
            Status = movie.Status,
            CreatedYear = movie.CreatedYear

        };
    }
}
