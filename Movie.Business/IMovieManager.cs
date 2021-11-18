using Movie.Business.DTO;

namespace Movie.Business;
public interface IMovieManager
{
    public Task<List<MovieDTO>> SearcyMovieByName(string name);
    public Task<MovieInfoDTO> GetInfoByMovieId(string id);
    public Task<List<MoviePosterDTO>> GetMoviePostersById(string id);
    public Task<DescriptionDTO> GetMovieDescriptionById(string id);
    public Task AddMovieToWatchListOfUser(MovieDetailDTO movie);
    public Task<List<WatchListDTO>> GetWatchListOfUser(int userId);
    public Task MarkMovieAsWatched(int userId, string movieId);
}
