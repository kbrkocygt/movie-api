using System;

namespace MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

public class GetMovieByIdQuery
{
    public GetMovieByIdQuery(int movieId)
    {
        MovieId = movieId;
    }

    public int MovieId { get; set; }
}
