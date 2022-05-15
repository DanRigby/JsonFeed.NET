namespace JsonFeedNet
{
    public static class JsonFeedExtensions
    {
        /// <summary>
        ///     Retrieves a remote feed from the specified Uri and parses it into a JsonFeed object for use by code.
        /// </summary>
        /// <param name="client">The HttpClient used to request the JSON Feed</param>
        /// <param name="jsonFeedUri">The Uri of the JSON Feed to retrieve and parse.</param>
        /// <returns>A JsonFeed object representing the parsed feed.</returns>
        public static async Task<JsonFeed> ParseFromUriAsync(this HttpClient client, Uri jsonFeedUri)
        {
            string jsonDocument = await client.GetStringAsync(jsonFeedUri);
            return JsonFeed.Parse(jsonDocument);
        }
    }
}
