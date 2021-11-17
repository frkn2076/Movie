using Microsoft.EntityFrameworkCore;
using Movie.DataAccess;
using Movie.DataAccess.Entity;

namespace Movie.Business
{
    public class MovieManager : IMovieManager
    {
        private readonly AppDBContext _context;
        public MovieManager(AppDBContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));

        private async Task AddMovie(WatchList watchList)
        {
            await _context.WatchLists.AddAsync(watchList);
            await _context.SaveChangesAsync();
        }

        private List<WatchList> GetMovies() => _context.WatchLists.AsNoTracking().ToList();


        Task IMovieManager.AddMovie(WatchList watchList) => AddMovie(watchList);
        List<WatchList> IMovieManager.GetMovies() => GetMovies();
    }
}