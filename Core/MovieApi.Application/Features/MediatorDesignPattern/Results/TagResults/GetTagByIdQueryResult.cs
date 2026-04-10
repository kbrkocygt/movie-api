using System;
using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;

public class GetTagByIdQueryResult : IRequest<GetTagByIdQueryResult>
{
    public int TagId { get; set; }
    public string Title { get; set; }
}
