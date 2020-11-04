using Aijkl.Abema.API.Internal;
using Aijkl.Abema.API.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Aijkl.Abema.API.Clients.Video
{
    public class RankingClient
    {
        private readonly APIClient apiClient;
        internal RankingClient(APIClient apiClient)
        {
            this.apiClient = apiClient;
        }
        /// <summary>
        /// https://api.abema.io/v1/video/rankings/view/genres/{contentsType}?limit={limit}
        /// </summary>        
        /// <returns></returns>
        public async Task<APIResult<Ranking>> Fetch(ContentsType contentsType,int limit = 50)
        {
            HttpRequestMessage requestMessage = Request.CreateGetRequest($"video/rankings/view/genres/{contentsType.ToString().ToLower()}?limit={limit}");
            return await apiClient.SendRequestAsync<Ranking>(requestMessage).ConfigureAwait(false);            
        }
    }
}
