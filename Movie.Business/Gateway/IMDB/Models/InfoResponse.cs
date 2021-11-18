namespace Movie.Business.Gateway.IMDB.Models;
public class InfoResponse
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string OriginalTitle { get; set; }
    public string FullTitle { get; set; }
    public string Type { get; set; }
    public string Year { get; set; }
    public string Image { get; set; }
    public string ReleaseDate { get; set; }
    public string RuntimeMins { get; set; }
    public string RuntimeStr { get; set; }
    public string Plot { get; set; }
    public string PlotLocal { get; set; }
    public bool PlotLocalIsRtl { get; set; }
    public string Awards { get; set; }
    public string Directors { get; set; }
    public List<SummaryResponse> DirectorList { get; set; }
    public string Writers { get; set; }
    public List<SummaryResponse> WriterList { get; set; }
    public string stars { get; set; }
    public List<SummaryResponse> StarList { get; set; }
    public List<ActorSummaryResponse> ActorList { get; set; }
    public string FullCast { get; set; }
    public string Genres { get; set; }
    public List<KeyValuePair<string, string>> GenreList { get; set; }
    public string Companies { get; set; }
    public List<SummaryResponse> CompanyList { get; set; }
    public string Countries { get; set; }
    public List<KeyValuePair<string, string>> CountryList { get; set; }
    public string Languages { get; set; }
    public List<KeyValuePair<string, string>> LanguageList { get; set; }
    public string ContentRating { get; set; }
    public string ImDbRating { get; set; }
    public string ImDbRatingVotes { get; set; }
    public string MetacriticRating { get; set; }
    public string Ratings { get; set; }
    public string Wikipedia { get; set; }
    public string Posters { get; set; }
    public string Images { get; set; }
    public string Trailer { get; set; }
    public BoxOfficeResponse BoxOffice { get; set; }
    public string Tagline { get; set; }
    public string Keywords { get; set; }
    public List<string> KeywordList { get; set; }
    public List<SimilarResponse> Similars { get; set; }
    public TvSeriesInfoResponse TvSeriesInfo { get; set; }
    public string TvEpisodeInfo { get; set; }
    public string ErrorMessage { get; set; }
}
