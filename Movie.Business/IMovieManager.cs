using Movie.DataAccess.Entity;

namespace Movie.Business
{
    public interface IMovieManager
    {
        public Task AddMovie(WatchList watchList);
        public List<WatchList> GetMovies();
    }
}
