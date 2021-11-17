namespace Movie.Business.DTO
{
    public class WatchListDTO
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool HasWatched { get; set; }
    }
}
