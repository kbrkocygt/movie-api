using System;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.SeriesCommand;

public class RemoveSeriesCommand
{
    public RemoveSeriesCommand(int seriesId)
    {
        SeriesId = seriesId;
    }

    public int SeriesId { get; set; }

}
