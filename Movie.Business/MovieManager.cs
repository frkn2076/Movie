using Microsoft.EntityFrameworkCore;
using Movie.Business.DTO;
using Movie.Business.Exceptions;
using Movie.Business.Gateway.IMDB;
using Movie.DataAccess;
using Movie.DataAccess.Entity;

namespace Movie.Business;
public class MovieManager : IMovieManager
{
    private readonly AppDBContext _context;
    private readonly IImdbConsumer _imdbConsumer;
    public MovieManager(AppDBContext context, IImdbConsumer imdbConsumer)
    {
        _context = context;
        _imdbConsumer = imdbConsumer;
    }

    private async Task<List<MovieDTO>> SearcyMovieByName(string name)
    {
        var movieResponse = await _imdbConsumer.SearchByName(name);
        if (movieResponse == null || !string.IsNullOrWhiteSpace(movieResponse.ErrorMessage) || !movieResponse.Results.Any())
        {
            throw new NoMovieFound();
        }

        var response = movieResponse.Results.Select(x => new MovieDTO()
        {
            Id = x.Id,
            Title = x.Title,
            Description = x.Description
        }).ToList();
        return response;
    }

    private async Task<MovieInfoDTO> GetInfoByMovieId(string id)
    {
        var infoResponse = await _imdbConsumer.GetInfoById(id);
        if (infoResponse == null || !string.IsNullOrWhiteSpace(infoResponse.ErrorMessage))
        {
            throw new MovieInfoNotFound();
        }

        var response = new MovieInfoDTO()
        {
            Id = infoResponse.Id,
            Title = infoResponse.Title,
            FullTitle = infoResponse.FullTitle,
            Year = infoResponse.Year,
            Awards = infoResponse.Awards,
            Stars = infoResponse.stars
        };
        return response;
    }

    private async Task<List<MoviePosterDTO>> GetMoviePostersById(string id)
    {
        var posterResponse = await _imdbConsumer.GetPostersById(id);
        if (posterResponse?.Posters == null || !string.IsNullOrWhiteSpace(posterResponse.ErrorMessage) || !posterResponse.Posters.Any())
        {
            throw new NoMoviePosterFound();
        }

        var response = posterResponse.Posters.Select(x => new MoviePosterDTO()
        {
            Id = x.Id,
            Link = x.Link,
        }).ToList();

        return response;
    }

    private async Task<DescriptionDTO> GetMovieDescriptionById(string id)
    {
        var descriptionResponse = await _imdbConsumer.GetDescriptionById(id);
        if (descriptionResponse?.PlotShort == null || !string.IsNullOrWhiteSpace(descriptionResponse.ErrorMessage))
        {
            throw new NoMoviePosterFound();
        }

        var response = new DescriptionDTO()
        {
            Text = descriptionResponse.PlotShort.PlainText,
            Html = descriptionResponse.PlotShort.Html
        };

        return response;
    }

    private async Task AddMovieToWatchListOfUser(MovieDetailDTO movie)
    {
        var isUserHasMovie = _context.WatchLists.AsNoTracking().Any(x => x.UserId == movie.UserId && x.MovieId == movie.MovieId);
        if (isUserHasMovie)
        {
            throw new UserAlreadyHasMovieInWatchList();
        }

        var watchList = new WatchList()
        {
            UserId = movie.UserId,
            MovieId = movie.MovieId,
            Title = movie.Title,
            Description = movie.Description
        };
        await _context.WatchLists.AddAsync(watchList);
        await _context.SaveChangesAsync();
    }

    private async Task<List<WatchListDTO>> GetWatchListOfUser(int userId)
    {
        var watchLists = _context.WatchLists.AsNoTracking().Where(x => x.UserId == userId).ToList();
        if (watchLists == null)
        {
            throw new NoWatchListFoundForUser();
        }

        var response = watchLists.Select(x => new WatchListDTO()
        {
            Id = x.MovieId,
            Description = x.Description,
            Title = x.Title,
            HasWatched = x.HasWatched
        }).ToList();

        return response;
    }

    private async Task MarkMovieAsWatched(int userId, string movieId)
    {
        var watchList = await _context.WatchLists.FirstOrDefaultAsync(x => x.UserId == userId && x.MovieId == movieId);
        if (watchList == null)
        {
            throw new NoMovieFoundForUser();
        }

        watchList.HasWatched = true;
        await _context.SaveChangesAsync();
    }


    #region Explicit Definitions
    Task<List<MovieDTO>> IMovieManager.SearcyMovieByName(string name) => SearcyMovieByName(name);
    Task<MovieInfoDTO> IMovieManager.GetInfoByMovieId(string id) => GetInfoByMovieId(id);
    Task<List<MoviePosterDTO>> IMovieManager.GetMoviePostersById(string id) => GetMoviePostersById(id);
    Task<DescriptionDTO> IMovieManager.GetMovieDescriptionById(string id) => GetMovieDescriptionById(id);
    Task IMovieManager.AddMovieToWatchListOfUser(MovieDetailDTO movie) => AddMovieToWatchListOfUser(movie);
    Task<List<WatchListDTO>> IMovieManager.GetWatchListOfUser(int userId) => GetWatchListOfUser(userId);
    Task IMovieManager.MarkMovieAsWatched(int userId, string movieId) => MarkMovieAsWatched(userId, movieId);
    #endregion
}
