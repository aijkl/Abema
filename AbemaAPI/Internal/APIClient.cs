using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Aijkl.Abema.API.Internal
{
    internal class APIClient
    {
        private readonly HttpClient httpClient;
        public APIClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        internal void AddHeader(string name, string value)
        {
            httpClient.DefaultRequestHeaders.Add(name, value);
        }
        internal void RemoveHeader(string name)
        {
            httpClient.DefaultRequestHeaders.Remove(name);
        }
        internal void SetCookie(Cookie cookie)
        {
            string value = string.Empty;
            value = httpClient.DefaultRequestHeaders.TryGetValues("Cookie", out IEnumerable<string> values) ? value + string.Join(" ", values) : value;
            value += $" {cookie.Name}={cookie.Value};";

            RemoveCookie();
            httpClient.DefaultRequestHeaders.Add("Cookie", value);
        }
        internal void SetBearerToken(string bearerToken)
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {bearerToken}");
        }
        internal void RemoveCookie()
        {
            httpClient.DefaultRequestHeaders.Remove("Cookie");
        }
        internal async Task<APIResult<T>> SendRequestAsync<T>(HttpRequestMessage httpRequest)
        {
            HttpResponseMessage response = await httpClient.SendAsync(httpRequest).ConfigureAwait(false);

            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NotModified)
            {
                new AbemaAPIException($"[AbemaAPI] Status:{response.StatusCode}", response);
            }

            if (response.StatusCode != HttpStatusCode.NotModified)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                APIResult<T> result = new APIResult<T>
                {
                    Result = JsonConvert.DeserializeObject<T>(responseBody, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All }),
                    ResponseBody = responseBody,
                    HttpStatusCode = response.StatusCode,
                    HttpResponseHeaders = response.Headers,
                    Etag = response.Headers.ETag
                };
                return result;
            }
            else
            {
                return new APIResult<T>() { HttpStatusCode = response.StatusCode };
            }
        }
        internal async Task<bool> SendRequestAsync(HttpRequestMessage httpRequest)
        {
            HttpResponseMessage response = await httpClient.SendAsync(httpRequest);
            return response.IsSuccessStatusCode;
        }
        internal async Task<HttpResponseMessage> SendRequestAysnc(HttpRequestMessage httpResponse)
        {
            return await httpClient.SendAsync(httpResponse);
        }
    }
}
