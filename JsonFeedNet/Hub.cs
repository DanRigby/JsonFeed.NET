namespace JsonFeedNet
{
    /// <summary>
    /// Endpoint that can be used to subscribe to real-time notifications of changes to a feed.
    /// </summary>
    public class Hub
    {
        /// <summary>
        /// The type field describes the protocol used to talk with the hub, such as “rssCloud” or “WebSub.”
        /// </summary>
        public string Type { get; set; } //type (required)

        /// <summary>
        /// Url of the hub endpoint.
        /// </summary>
        public string Url { get; set; } //url (required)
    }
}
