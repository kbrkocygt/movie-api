using System;
using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;

public class UpdateTagCommand : IRequest
{
    public int TagId { get; set; }
    public string Title { get; set; }
}
