using Movie.Business.Gateway.IMDB.Models;

namespace Movie.Business.Gateway.IMDB;
public interface IImdbConsumer
{
    public Task<SearchResponse> SearchByName(string movie);
    public Task<InfoResponse> GetInfoById(string id);
    public Task<PosterResponse> GetPostersById(string id);
    public Task<WikipediaResponse> GetDescriptionById(string id);
}
