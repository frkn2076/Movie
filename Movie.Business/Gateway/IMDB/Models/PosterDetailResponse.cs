namespace Movie.Business.Gateway.IMDB.Models
{
    public class PosterDetailResponse
    {
        public string Id { get; set; }
        public string Link { get; set; }
        public double AspectRatio { get; set; }
        public string Language { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}
