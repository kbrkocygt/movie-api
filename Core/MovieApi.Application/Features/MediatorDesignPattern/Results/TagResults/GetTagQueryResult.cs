using System;

namespace MovieApi.Application.Features.MediatorDesignPattern.Results.TagResults;

public class GetTagQueryResult
{
    public int TagId { get; set; }
    public string Title { get; set; }
}
