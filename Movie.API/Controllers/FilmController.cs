using Microsoft.AspNetCore.Mvc;
using Movie.API.Requests;
using Movie.API.Responses;
using Movie.Business;

namespace Movie.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IActionResult> SearchByName(string name)
        {
            var response = await _movieManager.SearcyMovieByName(name);
            return Ok(response);
        }

        [HttpPost("watchlist")]
        public async Task<IActionResult> AddWatchList(MovieRequest request)
        {
            var movieDTO = new MovieDetailDTO()
            {
                UserId = request.UserId,
                MovieId = request.Movie.Id,
                Description = request.Movie.Description,
                Title = request.Movie.Title
            };
            await _movieManager.AddMovieToWatchListOfUser(movieDTO);
            return Ok();
        }

        [HttpGet("watchlist/{userId}")]
        public async Task<IActionResult> GetWatchLists(int userId)
        {
            var watchListsDTO = await _movieManager.GetWatchListOfUser(userId);
            var response = new WatchListResponse();
            response.WatchLists = watchListsDTO.Select(x => new WatchListDetailResponse()
            {
                MovieId = x.Id,
                Description = x.Description,
                Title = x.Title,
                HasWatched = x.HasWatched
            }).ToList();

            return Ok(response);
        }

        [HttpPut("watchlist/{userId}")]
        public IActionResult MarkAsWatched(MovieRequest request, int userId)
        {
            return Ok(string.Empty);
        }
    }
}