using System;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommand;

public class RemoveMovieCommand
{
    public RemoveMovieCommand(int movieId)
    {
        MovieId = movieId;
    }

    public int MovieId { get; set; }

}
