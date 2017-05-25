using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace JsonFeedNet
{

    public class JsonFeed
    {
        /// <summary>
        /// The URL of the version of the format the feed uses.
        /// </summary>
        public string Version { get; set; } //version (required)

        /// <summary>
        /// The name of the feed.
        /// This will often correspond to the name of the website(blog, for instance).
        /// </summary>
        public string Title { get; set; } //title (required)

        /// <summary>
        /// The URL of the resource that the feed describes.
        /// This resource may or may not actually be a “home” page, but it should be an HTML page.
        /// </summary>
        public string HomePageUrl { get; set; } //home_page_url (optional)

        /// <summary>
        /// The URL of the feed.
        /// Serves as the unique identifier for the feed.
        /// </summary>
        public string FeedUrl { get; set; } //feed_url (optional)

        /// <summary>
        /// More detail, beyond the title, on what the feed is about.
        /// A feed reader may display this text.
        /// </summary>
        public string Description { get; set; } //description (optional)

        /// <summary>
        /// Description of the purpose of the feed.
        /// This is for the use of people looking at the raw JSON, and should be ignored by feed readers.
        /// </summary>
        public string UserComment { get; set; } //user_comment (optional)

        /// <summary>
        /// The URL of a feed that provides the next n items, where n is determined by the publisher.
        /// This allows for pagination, but with the expectation that reader software is not required to use it and probably won’t use it very often.
        /// Must not be the same as FeedUrl, and it must not be the same as a previous NextUrl (to avoid infinite loops).
        /// </summary>
        public string NextUrl { get; set; } //next_url (optional)

        /// <summary>
        /// The URL of an image for the feed suitable to be used in a timeline, much the way an avatar might be used.
        /// It should be square and relatively large — such as 512 x 512 — so that it can be scaled-down.
        /// It should use transparency where appropriate, since it may be rendered on a non-white background.
        /// </summary>
        public string Icon { get; set; } //icon (optional)

        /// <summary>
        /// The URL of an image for the feed suitable to be used in a source list.
        /// It should be square and relatively small, but not smaller than 64 x 64.
        /// It should use transparency where appropriate, since it may be rendered on a non-white background.
        /// </summary>
        public string FavIcon { get; set; } //favicon (optional)

        /// <summary>
        /// The feed author.
        /// </summary>
        public Author Author { get; set; } //author (optional)

        /// <summary>
        /// Indicates whether or not the feed is finished — that is, whether or not it will ever update again.
        /// If the value is true, then it’s expired. Any other value, or the absence of expired, means the feed may continue to update.
        /// </summary>
        public bool Expired { get; set; } //expired (optional)

        /// <summary>
        /// Endpoints that can be used to subscribe to real-time notifications of changes to this feed.
        /// </summary>
        public List<Hub> Hubs { get; set; } //hubs (optional)

        /// <summary>
        /// The individual items in the feed.
        /// </summary>
        public List<FeedItem> Items { get; set; } //items (required)

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
