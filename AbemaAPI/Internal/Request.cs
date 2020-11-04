using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace Aijkl.Abema.API.Internal
{
    internal static class Request
    {
        private const string BASE_URL = "https://api.abema.io/v1";
        private const string USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.111 Safari/537.36";
        internal static HttpRequestMessage CreateGetRequest(string verb, string apiKey = "", string etag = "", FetchDest fetchDest = FetchDest.Empty)
        {
            HttpRequestMessage httpRequestMessage = CreateDefaultRequest(etag, fetchDest);
            httpRequestMessage.Method = HttpMethod.Get;
            string conjunction = Regex.Match(verb, @"(.+)=\d+").Success ? "&" : "?";
            httpRequestMessage.RequestUri = new Uri($"{BASE_URL}/{verb}{(string.IsNullOrEmpty(apiKey) ? string.Empty : $"{conjunction}apiKey={apiKey}")}");
            return httpRequestMessage;
        }
        internal static HttpRequestMessage CreatePutRequest(string verb, string apiKey = "", string eTag = "", string json = "", FetchDest fetchDest = FetchDest.Empty)
        {
            HttpRequestMessage httpRequestMessage = CreateDefaultRequest(eTag, fetchDest);
            httpRequestMessage.Method = HttpMethod.Put;
            string conjunction = Regex.Match(verb, @"(.+)=\d+").Success ? "&" : "?";
            httpRequestMessage.RequestUri = new Uri($"{BASE_URL}/{verb}{(apiKey == null ? string.Empty : $"{conjunction}apiKey={apiKey}")}");
            httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, @"application/json");
            return httpRequestMessage;
        }
        internal static HttpRequestMessage CreatePostRequest(string verb, string apiKey = "", string eTag = "", string json = "", FetchDest fetchDest = FetchDest.Empty)
        {
            HttpRequestMessage httpRequestMessage = CreateDefaultRequest(eTag, fetchDest);
            httpRequestMessage.Method = HttpMethod.Post;
            string conjunction = Regex.Match(verb, @"(.+)=\d+").Success ? "&" : "?";
            httpRequestMessage.RequestUri = new Uri($"{BASE_URL}/{verb}{(apiKey == null ? string.Empty : $"{conjunction}apiKey={apiKey}")}");
            httpRequestMessage.Content = new StringContent(json, Encoding.UTF8, @"application/json");
            return httpRequestMessage;
        }
        internal static HttpRequestMessage CreateDeleteRequest(string verb, string apiKey = "", string eTag = "", FetchDest fetchDest = FetchDest.Empty)
        {
            HttpRequestMessage httpRequestMessage = CreateDefaultRequest(eTag, fetchDest);
            httpRequestMessage.Method = HttpMethod.Delete;
            string conjunction = Regex.Match(verb, @"(.+)=\d+").Success ? "&" : "?";
            httpRequestMessage.RequestUri = new Uri($"{BASE_URL}/{verb}{(apiKey == null ? string.Empty : $"{conjunction}apiKey={apiKey}")}");
            return httpRequestMessage;
        }
        private static HttpRequestMessage CreateDefaultRequest(string etag, FetchDest fetchDest)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage();            
            httpRequestMessage.Headers.Add("Connection", "keep-alive");
            httpRequestMessage.Headers.Add("Cache-Control", "max-age=0");
            httpRequestMessage.Headers.Add("User-Agent", USER_AGENT);
            httpRequestMessage.Headers.Add("Accept", "*/*");
            httpRequestMessage.Headers.Add("Accept-Language", "en-US,en;q=0.9");
            httpRequestMessage.Headers.Add("Accept-Encoding", "gzip");
            httpRequestMessage.Headers.Add("Sec-Fetch-Site", "cross-site");
            httpRequestMessage.Headers.Add("Sec-Fetch-Mode", "cors");
            httpRequestMessage.Headers.Add("Sec-Fetch-Dest", fetchDest.ToString().ToLower());
            if (etag != string.Empty) httpRequestMessage.Headers.Add("If-None-Match", etag);

            return httpRequestMessage;
        }
    }
}
