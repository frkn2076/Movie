namespace Movie.Business.Gateway.IMDB.Models;
public class PosterResponse
{
    public string ImDbId { get; set; }
    public string Title { get; set; }
    public string FullTitle { get; set; }
    public string Type { get; set; }
    public string Year { get; set; }
    public List<PosterDetailResponse> Posters { get; set; }
    public List<PosterDetailResponse> Backdrops { get; set; }
    public string ErrorMessage { get; set; }
}
