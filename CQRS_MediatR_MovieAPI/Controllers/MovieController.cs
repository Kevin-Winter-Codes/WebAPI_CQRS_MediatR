using CQRS_MediatR_MovieAPI.Commands;
using CQRS_MediatR_MovieAPI.Data.Entities;
using CQRS_MediatR_MovieAPI.Handlers;
using CQRS_MediatR_MovieAPI.Notifications;
using CQRS_MediatR_MovieAPI.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_MediatR_MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;


        public MovieController(IMediator mediator) => _mediator = mediator;

        [HttpGet]
        public async Task<ActionResult> GetMovies()
        {
            var products = await _mediator.Send(new GetMoviesQuery());

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetMovieById")]
        public async Task<ActionResult> GetMovieById(int id)
        {
            var movie = await _mediator.Send(new GetMovieByIdQuery(id));

            return Ok(movie);
        }


        [HttpPost]
        public async Task<ActionResult> AddMovie([FromBody] Movie movie)
        {
            var movieToReturn = await _mediator.Send(new AddMovieCommand(movie));

            await _mediator.Publish(new MovieAddedNotification(movieToReturn));

            return CreatedAtRoute("GetMovieById", new { id = movieToReturn.Id }, movieToReturn);
        }
    }
}
