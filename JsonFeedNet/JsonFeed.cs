namespace JsonFeedNet;

using System.Text;
using Newtonsoft.Json;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global
public class JsonFeed
{
    private static readonly JsonSerializerSettings s_serializerSettings = new()
    {
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore,
        DateFormatHandling = DateFormatHandling.IsoDateFormat
    };

    /// <summary>
    ///     The URL of the version of the format the feed uses.
    /// </summary>
    [JsonProperty("version")]
    public string Version { get; set; } = "https://jsonfeed.org/version/1.1"; //required

    /// <summary>
    ///     The name of the feed.
    ///     This will often correspond to the name of the website(blog, for instance).
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; set; } //required

    /// <summary>
    ///     The URL of the resource that the feed describes.
    ///     This resource may or may not actually be a “home” page, but it should be an HTML page.
    /// </summary>
    [JsonProperty("home_page_url")]
    public string HomePageUrl { get; set; } //optional

    /// <summary>
    ///     The URL of the feed.
    ///     Serves as the unique identifier for the feed.
    /// </summary>
    [JsonProperty("feed_url")]
    public string FeedUrl { get; set; } //optional

    /// <summary>
    ///     More detail, beyond the title, on what the feed is about.
    ///     A feed reader may display this text.
    /// </summary>
    [JsonProperty("description")]
    public string Description { get; set; } //optional

    /// <summary>
    ///     Description of the purpose of the feed.
    ///     This is for the use of people looking at the raw JSON, and should be ignored by feed readers.
    /// </summary>
    [JsonProperty("user_comment")]
    public string UserComment { get; set; } //optional

    /// <summary>
    ///     The URL of a feed that provides the next n items, where n is determined by the publisher.
    ///     This allows for pagination, but with the expectation that reader software is not required to use it and probably
    ///     won’t use it very often.
    ///     Must not be the same as FeedUrl, and it must not be the same as a previous NextUrl (to avoid infinite loops).
    /// </summary>
    [JsonProperty("next_url")]
    public string NextUrl { get; set; } //optional

    /// <summary>
    ///     The URL of an image for the feed suitable to be used in a timeline, much the way an avatar might be used.
    ///     It should be square and relatively large — such as 512 x 512 — so that it can be scaled-down.
    ///     It should use transparency where appropriate, since it may be rendered on a non-white background.
    /// </summary>
    [JsonProperty("icon")]
    public string Icon { get; set; } //optional

    /// <summary>
    ///     The URL of an image for the feed suitable to be used in a source list.
    ///     It should be square and relatively small, but not smaller than 64 x 64.
    ///     It should use transparency where appropriate, since it may be rendered on a non-white background.
    /// </summary>
    [JsonProperty("favicon")]
    public string FavIcon { get; set; } //optional

    /// <summary>
    ///     The feed author.
    /// </summary>
    [JsonProperty("author")]
    [Obsolete("obsolete by specification version 1.1. Use `Authors`")]
    public JsonFeedAuthor Author { get; set; } //optional

    /// <summary>
    ///     Specifies one or more feed authors.
    /// </summary>
    [JsonProperty("authors")]
    public List<JsonFeedAuthor> Authors { get; set; } //optional

    /// <summary>
    ///     Primary language for the feed in the format specified in RFC 5646.
    ///     The value is usually a 2-letter language tag from ISO 639-1, optionally followed by a region tag.
    ///     (Examples: en or en-US.)
    /// </summary>
    [JsonProperty("language")]
    public string Language { get; set; } //optional

    /// <summary>
    ///     Indicates whether or not the feed is finished — that is, whether or not it will ever update again.
    ///     If the value is true, then it’s expired. Any other value, or the absence of expired, means the feed may continue to
    ///     update.
    /// </summary>
    [JsonProperty("expired")]
    public bool? Expired { get; set; } //optional

    /// <summary>
    ///     Endpoints that can be used to subscribe to real-time notifications of changes to this feed.
    /// </summary>
    [JsonProperty("hubs")]
    public List<JsonFeedHub> Hubs { get; set; } //optional

    /// <summary>
    ///     The individual items in the feed.
    /// </summary>
    [JsonProperty("items")]
    public List<JsonFeedItem> Items { get; set; } //required

    /// <summary>
    ///     Parses a JsonFeed in an input string into a JsonFeed object for use by code.
    /// </summary>
    /// <param name="jsonFeedString">The JSON Feed as a string.</param>
    /// <returns>A JsonFeed object representing the parsed feed.</returns>
    public static JsonFeed Parse(string jsonFeedString)
    {
        return JsonConvert.DeserializeObject<JsonFeed>(jsonFeedString);
    }

    /// <summary>
    ///     Retrieves a remote feed from the specified Uri and parses it into a JsonFeed object for use by code.
    /// </summary>
    /// <param name="jsonFeedUri">The Uri of the JSON Feed to retrieve and parse.</param>
    /// <param name="httpMessageHandler">Optional: A customer HttpMessageHandler implementation to use for the network requests(s).</param>
    /// <returns>A JsonFeed object representing the parsed feed.</returns>
    public static async Task<JsonFeed> ParseFromUriAsync(Uri jsonFeedUri, HttpMessageHandler httpMessageHandler = null)
    {
        HttpClient client = new(httpMessageHandler ?? new HttpClientHandler());
        string jsonDocument = await client.GetStringAsync(jsonFeedUri);

        return Parse(jsonDocument);
    }

    /// <summary>
    ///     Serializes the JsonFeed object into a JSON string.
    /// </summary>
    /// <returns>A string containing the generated feed JSON.</returns>
    public string Write()
    {
        return ToString();
    }

    /// <summary>
    ///     Serializes the JsonFeed object into a JSON string and writes it to the provided stream.
    /// </summary>
    /// <param name="stream">The stream to write the JSON to.</param>
    public void Write(Stream stream)
    {
        var encoding = new UTF8Encoding(false);
        var writer = new StreamWriter(stream, encoding);
        writer.Write(this);
        writer.Flush();
    }

    /// <summary>
    ///     Serializes the JsonFeed object into a JSON string.
    /// </summary>
    /// <returns>A string containing the generated feed JSON.</returns>
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this, s_serializerSettings);
    }
}
