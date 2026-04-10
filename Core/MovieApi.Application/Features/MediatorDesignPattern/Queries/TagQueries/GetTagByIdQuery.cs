using System;
using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;

public class GetTagByIdQuery : IRequest<GetTagByIdQueryResult>
{
    public GetTagByIdQuery(int tagId)
    {
        TagId = tagId;
    }

    public int TagId { get; set; }

}
