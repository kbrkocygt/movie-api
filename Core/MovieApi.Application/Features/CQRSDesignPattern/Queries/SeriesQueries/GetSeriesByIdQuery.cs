using System;

namespace MovieApi.Application.Features.CQRSDesignPattern.Queries.SeriesQueries;

public class GetSeriesByIdQuery
{
    public int SeriesId { get; set; }
    public GetSeriesByIdQuery(int seriesId)
    {
        SeriesId = seriesId;
    }
}
