using Microsoft.AspNetCore.Mvc;
using Movie.API.Requests;
using Movie.Business;
using Movie.DataAccess.Entity;

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
        public IActionResult SearchByName(string name)
        {
            return Ok(string.Empty);
        }

        [HttpPost("watchlist/{userId}")]
        public IActionResult AddWatchList(MovieRequest request, int userId)
        {
            return Ok(string.Empty);
        }

        [HttpGet("watchlist/{userId}")]
        public IActionResult GetWatchLists(int userId)
        {
            return Ok(string.Empty);
        }

        [HttpPut("watchlist/{userId}")]
        public IActionResult MarkAsWatched(MovieRequest request, int userId)
        {
            return Ok(string.Empty);
        }
    }
}