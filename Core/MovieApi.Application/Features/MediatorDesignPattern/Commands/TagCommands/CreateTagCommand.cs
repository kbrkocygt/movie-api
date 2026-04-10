using System;
using MediatR;

namespace MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;

public class CreateTagCommand : IRequest
{

    public string Title { get; set; }
}
