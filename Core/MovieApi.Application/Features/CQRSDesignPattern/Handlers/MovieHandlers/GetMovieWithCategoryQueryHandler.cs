using System;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.CQRSDesignPattern.Results.MovieResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;

public class GetMovieWithCategoryQueryHandler
{
    private readonly MovieContext _context;
    public GetMovieWithCategoryQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<List<GetMovieWithCategoryQueryResult>> Handle()
    {
        var movies = _context.Movies.Include(m => m.Category).ToList();
        return movies.Select(m => new GetMovieWithCategoryQueryResult
        {
            MovieId = m.MovieId,
            Title = m.Title,
            Description = m.Description,
            CoverImageUrl = m.CoverImageUrl,
            ReleaseDate = m.ReleaseDate,
            Rating = m.Rating,
            Duration = m.Duration,
            Status = m.Status,
            CreatedYear = m.CreatedYear,
            CategoryId = m.CategoryId,
            CategoryName = m.Category.CategoryName
        }).ToList();
    }
}
