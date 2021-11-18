using Movie.Business;
using Movie.Business.Notifier;

namespace Movie.API.Job;
public static class Batch
{
    private static IMovieManager _movieManager;
    public static void Configure(IMovieManager movieManager) => _movieManager = movieManager;

    public async static Task SendMostRatedMovie(string to)
    {
        // userId set as 1 since there is no saved user
        var movieIds = await _movieManager.GetMostRatedMovieIds(1);
        if (movieIds == null || !movieIds.Any())
            return;

        var tasks = movieIds.Select(x => _movieManager.GetInfoByMovieId(x)).ToList();

        var responses = await Task.WhenAll(tasks);

        var mostRatedMovie = responses.Where(x => x != null).MaxBy(x => Convert.ToDouble(x.Rating));

        if (mostRatedMovie == null)
            return;

        var posters = await _movieManager.GetMoviePostersById(mostRatedMovie.Id);
        var poster = posters.FirstOrDefault(x => !string.IsNullOrWhiteSpace(x.Link));

        var movieDescription = await _movieManager.GetMovieDescriptionById(mostRatedMovie.Id);

        MailSender.SendMail(to, mostRatedMovie.Title, mostRatedMovie.Rating, poster?.Link, movieDescription.Html);
    }
}
