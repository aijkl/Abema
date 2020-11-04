using System;
using System.Net.Http;

namespace Aijkl.Abema.API
{
    public class AbemaAPIException : Exception
    {
        public AbemaAPIException(string message, HttpResponseMessage httpResponse) : base(message)
        {
            HttpResponseMessage = httpResponse;
        }
        public HttpResponseMessage HttpResponseMessage { private set; get; }
    }
}
