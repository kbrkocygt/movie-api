using System;
using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.ReviewResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.ReviewQueries;

public class GetReviewQuery : IRequest<List<GetReviewQueryResult>>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
}
