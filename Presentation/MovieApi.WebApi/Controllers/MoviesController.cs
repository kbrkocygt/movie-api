using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommand;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.MovieQueries;

namespace MovieApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly GetMovieByIdQueryHandler _getMovieByIdQueryHandler;
        private readonly GetMovieQueryHandler _getMovieQueryHandler;
        private readonly CreateMovieCommandHandler _createMovieCommandHandler;
        private readonly UpdateMovieCommandHandler _updateMovieCommandHandler;
        private readonly RemoveMovieCommandHandler _removeMovieCommandHandler;
        private readonly GetMovieWithCategoryQueryHandler _getMovieWithCategoryQueryHandler;

        public MoviesController(GetMovieByIdQueryHandler getMovieByIdQueryHandler, GetMovieQueryHandler getMovieQueryHandler, CreateMovieCommandHandler createMovieCommandHandler, UpdateMovieCommandHandler updateMovieCommandHandler, RemoveMovieCommandHandler removeMovieCommandHandler, GetMovieWithCategoryQueryHandler getMovieWithCategoryQueryHandler)
        {
            _getMovieByIdQueryHandler = getMovieByIdQueryHandler;
            _getMovieQueryHandler = getMovieQueryHandler;
            _createMovieCommandHandler = createMovieCommandHandler;
            _updateMovieCommandHandler = updateMovieCommandHandler;
            _removeMovieCommandHandler = removeMovieCommandHandler;
            _getMovieWithCategoryQueryHandler = getMovieWithCategoryQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> MovieList()
        {
            var movies = await _getMovieQueryHandler.Handle();
            return Ok(movies);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMovie(CreateMovieCommand command)
        {
            await _createMovieCommandHandler.Handle(command);
            return Ok("Movie created successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveMovie(int id)
        {
            await _removeMovieCommandHandler.Handle(new RemoveMovieCommand(id));
            return Ok("Movie removed successfully.");
        }
        [HttpGet("GetMovieById")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movie = await _getMovieByIdQueryHandler.Handle(new GetMovieByIdQuery(id));
            return Ok(movie);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(UpdateMovieCommand command)
        {
            await _updateMovieCommandHandler.Handle(command);
            return Ok("Movie updated successfully.");
        }

        [HttpGet("GetMovieWithCategory")]
        public async Task<IActionResult> GetMovieWithCategory()
        {
            var moviesWithCategory = await _getMovieWithCategoryQueryHandler.Handle();
            return Ok(moviesWithCategory);
        }
    }
}
