using System;

namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.CategoryCommands;

public class CreateCategoryCommand
{
    public string CategoryName { get; set; }
}
