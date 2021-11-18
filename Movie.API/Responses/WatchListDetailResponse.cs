namespace Movie.API.Responses;
public class WatchListDetailResponse
{
    public string MovieId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool HasWatched { get; set; }
}
