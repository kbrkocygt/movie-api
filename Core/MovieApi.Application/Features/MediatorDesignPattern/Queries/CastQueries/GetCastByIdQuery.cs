using System;
using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults;

namespace MovieApi.Application.Features.MediatorDesignPattern.Queries.CastQueries;

public class GetCastByIdQuery : IRequest<GetCastByIdQueryResult>
{
    public int CastId { get; set; }
    public GetCastByIdQuery(int castId)
    {
        CastId = castId;
    }


}


