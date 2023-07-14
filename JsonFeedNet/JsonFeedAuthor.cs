namespace JsonFeedNet;

using Newtonsoft.Json;

/// <summary>
///     A feed author.
/// </summary>
public class JsonFeedAuthor
{
    /// <summary>
    ///     The author's name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; } //optional

    /// <summary>
    ///     The URL of a site owned by the author.
    ///     It could be a blog, micro-blog, Twitter account, and so on.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } //optional

    /// <summary>
    ///     The URL for an image for the author.
    ///     It should be square and relatively large — such as 512 x 512.
    ///     It should use transparency where appropriate, since it may be rendered on a non-white background.
    /// </summary>
    [JsonProperty("avatar")]
    public string Avatar { get; set; } //optional
}
