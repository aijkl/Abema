using Aijkl.Abema.API.Clients.Video;
using Aijkl.Abema.API.Internal;
using System;
using System.Net.Cache;
using System.Net.Http;

namespace Aijkl.Abema.API
{
    public class AbemaClient
    {
        private readonly HttpClient httpClient;
        private readonly APIClient apiClient;
        public AbemaClient(string authorization)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                AutomaticDecompression = System.Net.DecompressionMethods.All
            };
            httpClient = new HttpClient(httpClientHandler);
            apiClient = new APIClient(httpClient);
            apiClient.SetBearerToken(authorization);
        }
        public RankingClient Ranking => new RankingClient(apiClient);
    }
}
