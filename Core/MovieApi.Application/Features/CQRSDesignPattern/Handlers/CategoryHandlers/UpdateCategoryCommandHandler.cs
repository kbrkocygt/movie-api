using System;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommand;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.CQRSDesignPattern.Handlers.CategoryHandlers;

public class UpdateCategoryCommandHandler
{
    private readonly MovieContext _context;
    public UpdateCategoryCommandHandler(MovieContext context)
    {
        _context = context;
    }
    public async Task Handle(UpdateCategoryCommand command)
    {
        var value = await _context.Categories.FindAsync(command.CategoryId);
        value.CategoryName = command.CategoryName;
        await _context.SaveChangesAsync();
    }
}
