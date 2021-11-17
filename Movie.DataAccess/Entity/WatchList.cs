namespace Movie.DataAccess.Entity
{
    public class WatchList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool HasWatched { get; set; }
    }
}
