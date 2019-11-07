using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace MongoSample
{
    // Simple extension methods that we are adding as part of the overall package
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsync<T>(this HttpClient httpClient, string requestUri, T data, string mediaType = "application/json")
        {
            MediaTypeFormatterCollection formatters = new MediaTypeFormatterCollection();

            var request = new HttpRequestMessage<T>(data, mediaType)
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(requestUri),
            };

            return httpClient.SendAsync(request);
        }
    }
}
