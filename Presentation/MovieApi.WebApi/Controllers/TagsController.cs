using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.TagCommands;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.TagQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TagList()
        {
            var result = await _mediator.Send(new GetTagQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTag([FromBody] CreateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok("Tag created successfully.");
        }
        [HttpGet("GetTagById")]
        public async Task<IActionResult> GetTagById(int id)
        {
            var result = await _mediator.Send(new GetTagByIdQuery(id));
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTag(int id)
        {
            await _mediator.Send(new RemoveTagCommand(id));
            return Ok("Tag deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTag(UpdateTagCommand command)
        {
            await _mediator.Send(command);
            return Ok("Tag updated successfully.");
        }
    }
}
