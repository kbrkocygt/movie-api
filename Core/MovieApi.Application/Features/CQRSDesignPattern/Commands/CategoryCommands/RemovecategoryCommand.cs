using System;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;

public class RemovecategoryCommand
{
    public int CategoryId { get; set; }

    public RemovecategoryCommand(int categoryId)
    {
        CategoryId = categoryId;
    }
}
