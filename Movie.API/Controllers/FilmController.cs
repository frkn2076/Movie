using Mapster;
using Microsoft.AspNetCore.Mvc;
using Movie.API.Requests;
using Movie.API.Responses;
using Movie.Business;
using Movie.Business.DTO;
using Swashbuckle.AspNetCore.Annotations;

namespace Movie.API.Controllers;
[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
public class FilmController : ControllerBase
{
    private readonly ILogger<FilmController> _logger;
    private readonly IMovieManager _movieManager;

    public FilmController(ILogger<FilmController> logger, IMovieManager movieManager)
    {
        _logger = logger;
        _movieManager = movieManager;
    }

    [HttpGet("search/{name}")]
    [ProducesResponseType(typeof(List<MovieResponse>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Search movie by name", Description = "Searches movie by given key and returns it")]
    public async Task<IActionResult> SearchByName(string name)
    {
        var moviesDTO = await _movieManager.SearcyMovieByName(name);
        var response = moviesDTO.Adapt<List<MovieResponse>>();
        return Ok(response);
    }

    [HttpPost("watchlist")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Add watchlist", Description = "Adds the movie to the user's watchlist")]
    public async Task<IActionResult> AddWatchList(MovieRequest request)
    {
        var movieDTO = request.Adapt<MovieDetailDTO>();
        await _movieManager.AddMovieToWatchListOfUser(movieDTO);
        return Ok();
    }

    [HttpGet("watchlist/{userId}")]
    [ProducesResponseType(typeof(WatchListResponse), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Get watchlists", Description = "Get watchlists of the user")]
    public async Task<IActionResult> GetWatchLists(int userId)
    {
        var watchListsDTO = await _movieManager.GetWatchListOfUser(userId);
        var response = new WatchListResponse()
        {
            WatchLists = watchListsDTO.Adapt<List<WatchListDetailResponse>>()
        };
        return Ok(response);
    }

    [HttpPut("watchlist/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Mark as watched", Description = "Marks movie as watched for the user")]
    public async Task<IActionResult> MarkAsWatched(MarkMovieRequest request, int userId)
    {
        await _movieManager.MarkMovieAsWatched(userId, request.MovieId);
        return Ok();
    }

    [HttpPost("groupfilms")]
    [ProducesResponseType(typeof(List<MovieGroupResponse>), StatusCodes.Status200OK)]
    [SwaggerOperation(Summary = "Group movies", Description = "Group the movies sent on request by genre")]
    public async Task<IActionResult> GroupMovies(MovieCollectionRequest request)
    {
        

        return Ok();
    }
}
