using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace JsonFeedNet
{
    public class JsonFeed
    {
        public static async Task<JsonFeed> ParseFromStringAsync(string jsonFeedString)
        {
            return await Task.FromResult(new JsonFeed());
        }

        public static async Task<JsonFeed> ParseFromStreamAsync(Stream jsonFeedStream)
        {
            return await Task.FromResult(new JsonFeed());
        }

        public static async Task<JsonFeed> ParseFromUriAsync(Uri jsonFeedUri, HttpMessageHandler httpMessageHandler = null)
        {
            var client = new HttpClient(httpMessageHandler ?? new HttpClientHandler());
            string jsonDocument = await client.GetStringAsync(jsonFeedUri);

            return new JsonFeed();
        }

        public async Task<string> WriteToStringAsync()
        {
            return await Task.FromResult(string.Empty);
        }

        public async Task WriteToStreamAsync(Stream outputStream)
        {
            await Task.FromResult(0);
        }
    }
}
