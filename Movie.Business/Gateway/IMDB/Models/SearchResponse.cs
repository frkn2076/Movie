namespace Movie.Business.Gateway.IMDB.Models
{
    public class SearchResponse
    {
        public string SearchType { get; set; }
        public string Expression { get; set; }
        public List<SearchDetailResponse> Results { get; set; }
        public string ErrorMessage { get; set; }

    }
}
