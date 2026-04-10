using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Application.Features.MediatorDesignPattern.Queries.ReviewQueries;
using MovieApi.Persistence.Context;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly MovieContext _movieContext;
        public ReviewsController(IMediator mediator, MovieContext movieContext)
        {
            _mediator = mediator;
            _movieContext = movieContext;
        }

        [HttpGet]
        public async Task<IActionResult> ReviewList([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var totalCount = await _movieContext.Reviews.CountAsync();
            Response.Headers.Add("X-Total-Count", totalCount.ToString());
            var result = await _mediator.Send(new GetReviewQuery { Page = page, PageSize = pageSize });
            return Ok(result);
        }

        // [HttpPost]
        // public async Task<IActionResult> CreateReview([FromBody] CreateReviewCommand command)
        // {
        //     await _mediator.Send(command);
        //     return Ok("Review created successfully.");
        // }
        // [HttpGet("GetReviewById")]
        // public async Task<IActionResult> GetReviewById(int id)
        // {
        //     var result = await _mediator.Send(new GetReviewByIdQuery(id));
        //     return Ok(result);
        // }

        // [HttpDelete]
        // public async Task<IActionResult> RemoveTag(int id)
        // {
        //     await _mediator.Send(new RemoveTagCommand(id));
        //     return Ok("Tag deleted successfully.");
        // }

        // [HttpPut]
        // public async Task<IActionResult> UpdateTag(UpdateTagCommand command)
        // {
        //     await _mediator.Send(command);
        //     return Ok("Tag updated successfully.");
        // }
    }
}
