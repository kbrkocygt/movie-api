using System;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.ReviewQueries;
using MovieApi.Application.Features.MediatorDesignPattern.Results.ReviewResults;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.ReviewHandlers;

public class GetReviewQueryHandler : IRequestHandler<GetReviewQuery, List<GetReviewQueryResult>>
{
    private readonly MovieContext _context;
    public GetReviewQueryHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task<List<GetReviewQueryResult>> Handle(GetReviewQuery request, CancellationToken cancellationToken)
    {
        var values = await _context.Reviews
        .Skip((request.Page - 1) * request.PageSize)
        .Take(request.PageSize)
        .Select(v => new GetReviewQueryResult
        {
            ReviewId = v.ReviewId,
            ReviewComment = v.ReviewComment,
            UserRating = v.UserRating,
            ReviewDate = v.ReviewDate,
            Status = v.Status,
            UserId = v.UserId,
            MovieId = v.MovieId,
            IsSpoiler = v.IsSpoiler,
            LikeCount = v.LikeCount,
            SentimentScore = v.SentimentScore
        }).ToListAsync();

        return values;
    }
}
