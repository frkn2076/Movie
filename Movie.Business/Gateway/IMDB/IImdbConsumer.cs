namespace Movie.Business.Gateway
{
    public interface IImdbConsumer
    {
        public void SearchByName(string movie);
        public void GetInfoById(string id);
        public void GetPostersById(string id);
        public void GetDescriptionById(string id);
    }
}
