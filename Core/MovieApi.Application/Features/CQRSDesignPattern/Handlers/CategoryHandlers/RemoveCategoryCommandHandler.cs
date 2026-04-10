using System;
using System.Reflection.Metadata;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

public class RemoveCategoryCommandHandler
{
    private readonly MovieContext _contex;
    public RemoveCategoryCommandHandler(MovieContext context)
    {
        _contex = context;
    }

    public async Task Handle(RemovecategoryCommand command)
    {
        var value = await _contex.Categories.FindAsync(command.CategoryId);
        _contex.Categories.Remove(value);
        await _contex.SaveChangesAsync();
    }
}
