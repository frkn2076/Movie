using Microsoft.Extensions.Configuration;

namespace Movie.Business.Gateway
{
    public class ImdbConsumer : IImdbConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        public ImdbConsumer(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        private void SearchByName(string movie)
        {

        }

        private void GetInfoById(string id)
        {

        }

        private void GetPostersById(string id)
        {

        }

        private void GetDescriptionById(string id)
        {

        }

        #region Explicit Definitions

        void IImdbConsumer.SearchByName(string movie) => SearchByName(movie);
        void IImdbConsumer.GetInfoById(string id) => GetInfoById(id);
        void IImdbConsumer.GetPostersById(string id) => GetPostersById(id);
        void IImdbConsumer.GetDescriptionById(string id) => GetDescriptionById(id);

        #endregion

    }
}
