using Microsoft.Extensions.Configuration;
using Movie.Business.Gateway.IMDB.Models;
using Newtonsoft.Json;

namespace Movie.Business.Gateway.IMDB
{
    public class ImdbConsumer : IImdbConsumer
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        public ImdbConsumer(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
            _apiKey = configuration["Services:IMDB:APIKey"];
        }

        private async Task<SearchResponse> SearchByName(string movie)
        {
            var subUrl = $"Search/{_apiKey}/{movie}";
            var httpResponse = await _httpClient.GetAsync(subUrl);
            httpResponse.EnsureSuccessStatusCode();
            string responseBody = await httpResponse.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<SearchResponse>(responseBody);
            ArgumentNullException.ThrowIfNull(response);
            return response;
        }

        private async Task<InfoResponse> GetInfoById(string id)
        {
            var subUrl = $"Title/{_apiKey}/{id}";
            var httpResponse = await _httpClient.GetAsync(subUrl);
            httpResponse.EnsureSuccessStatusCode();
            string responseBody = await httpResponse.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<InfoResponse>(responseBody);
            ArgumentNullException.ThrowIfNull(response);
            return response;
        }

        private async Task<PosterResponse> GetPostersById(string id)
        {
            var subUrl = $"Posters/{_apiKey}/{id}";
            var httpResponse = await _httpClient.GetAsync(subUrl);
            httpResponse.EnsureSuccessStatusCode();
            string responseBody = await httpResponse.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<PosterResponse>(responseBody);
            ArgumentNullException.ThrowIfNull(response);
            return response;
        }

        private async Task<WikipediaResponse> GetDescriptionById(string id)
        {
            var subUrl = $"Wikipedia/{_apiKey}/{id}";
            var httpResponse = await _httpClient.GetAsync(subUrl);
            httpResponse.EnsureSuccessStatusCode();
            string responseBody = await httpResponse.Content.ReadAsStringAsync();

            var response = JsonConvert.DeserializeObject<WikipediaResponse>(responseBody);
            ArgumentNullException.ThrowIfNull(response);
            return response;
        }

        #region Explicit Definitions
        Task<SearchResponse> IImdbConsumer.SearchByName(string movie) => SearchByName(movie);
        Task<InfoResponse> IImdbConsumer.GetInfoById(string id) => GetInfoById(id);
        Task<PosterResponse> IImdbConsumer.GetPostersById(string id) => GetPostersById(id);
        Task<WikipediaResponse> IImdbConsumer.GetDescriptionById(string id) => GetDescriptionById(id);
        #endregion
    }
}
