using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Application.Features.CQRSDesignPattern.Commands.SeriesCommand;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.MovieHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Handlers.SeriesHandlers;
using MovieApi.Application.Features.CQRSDesignPattern.Queries.SeriesQueries;

namespace SeriesApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesesController : ControllerBase
    {
        private readonly GetSeriesByIdQueryHandler _getSeriesByIdQueryHandler;
        private readonly GetSeriesQueryHandler _getSeriesQueryHandler;
        private readonly CreateSeriesCommandHandler _createSeriesCommandHandler;
        private readonly UpdateSeriesCommandHandler _updateSeriesCommandHandler;
        private readonly RemoveSeriesCommandHandler _removeSeriesCommandHandler;
        private readonly GetSeriesWithCategoryQueryHandler _getSeriesWithCategoryQueryHandler;

        public SeriesesController(GetSeriesByIdQueryHandler getSeriesByIdQueryHandler, GetSeriesQueryHandler getSeriesQueryHandler, CreateSeriesCommandHandler createSeriesCommandHandler, UpdateSeriesCommandHandler updateSeriesCommandHandler, RemoveSeriesCommandHandler removeSeriesCommandHandler, GetSeriesWithCategoryQueryHandler getSeriesWithCategoryQueryHandler)
        {
            _getSeriesByIdQueryHandler = getSeriesByIdQueryHandler;
            _getSeriesQueryHandler = getSeriesQueryHandler;
            _createSeriesCommandHandler = createSeriesCommandHandler;
            _updateSeriesCommandHandler = updateSeriesCommandHandler;
            _removeSeriesCommandHandler = removeSeriesCommandHandler;
            _getSeriesWithCategoryQueryHandler = getSeriesWithCategoryQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> SeriesList()
        {
            var Seriess = await _getSeriesQueryHandler.Handle();
            return Ok(Seriess);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSeries(CreateSeriesCommand command)
        {
            await _createSeriesCommandHandler.Handle(command);
            return Ok("Series created successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSeries(int id)
        {
            await _removeSeriesCommandHandler.Handle(new RemoveSeriesCommand(id));
            return Ok("Series removed successfully.");
        }
        [HttpGet("GetSeriesById")]
        public async Task<IActionResult> GetSeriesById(int id)
        {
            var Series = await _getSeriesByIdQueryHandler.Handle(new GetSeriesByIdQuery(id));
            return Ok(Series);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSeries(UpdateSeriesCommand command)
        {
            await _updateSeriesCommandHandler.Handle(command);
            return Ok("Series updated successfully.");
        }
        [HttpGet("GetSeriesWithCategory")]
        public async Task<IActionResult> GetSeriesWithCategory()
        {
            var Series = await _getSeriesWithCategoryQueryHandler.Handle();
            return Ok(Series);
        }
    }
}
