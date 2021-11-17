namespace Movie.Business.Gateway.IMDB.Models
{
    public class TvSeriesInfoResponse
    {
        public string YearEnd { get; set; }
        public string Creators { get; set; }
        public List<SummaryResponse> CreatorList { get; set; }
        public List<string> Seasons { get; set; }
    }
}
