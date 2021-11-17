namespace Movie.API.Requests
{
    public class MovieRequest
    {
        public int UserId { get; set; }
        public MovieDetailRequest Movie { get; set; }
    }
}
