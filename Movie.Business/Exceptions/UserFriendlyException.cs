namespace Movie.Business.Exceptions
{
    public class NoMovieFound : Exception
    {
        public NoMovieFound() : base("No movie found") { }
    }

    public class MovieInfoNotFound : Exception
    {
        public MovieInfoNotFound() : base("Movie info not found") { }
    }

    public class NoMoviePosterFound : Exception
    {
        public NoMoviePosterFound() : base("No movie poster found") { }
    }

    public class NoMovieDescriptionFound : Exception
    {
        public NoMovieDescriptionFound() : base("No movie description found") { }
    }

    public class NoWatchListFoundForUser : Exception
    {
        public NoWatchListFoundForUser() : base("No watchlist found for user") { }
    }
}
