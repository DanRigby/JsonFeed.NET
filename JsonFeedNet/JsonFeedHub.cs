namespace JsonFeedNet;

using Newtonsoft.Json;

/// <summary>
///     Endpoint that can be used to subscribe to real-time notifications of changes to a feed.
/// </summary>
public class JsonFeedHub
{
    /// <summary>
    ///     The type field describes the protocol used to talk with the hub, such as “rssCloud” or “WebSub.”
    /// </summary>
    [JsonProperty("type")]
    public string Type { get; set; } //required

    /// <summary>
    ///     Url of the hub endpoint.
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; } //required
}
