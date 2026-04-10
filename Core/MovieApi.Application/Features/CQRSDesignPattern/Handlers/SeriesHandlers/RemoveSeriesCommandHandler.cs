using System;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.SeriesCommand;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;

public class RemoveSeriesCommandHandler
{
    private readonly MovieContext _context;
    public RemoveSeriesCommandHandler(MovieContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveSeriesCommand command)
    {
        var value = await _context.Serieses.FindAsync(command.SeriesId);
        _context.Serieses.Remove(value);
        await _context.SaveChangesAsync();



    }
}
