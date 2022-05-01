// ReSharper disable ClassNeverInstantiated.Global

using System;
using Newtonsoft.Json;

namespace JsonFeedNet
{
    /// <summary>
    ///     Endpoint that can be used to subscribe to real-time notifications of changes to a feed.
    /// </summary>
    public class JsonFeedHub : IEquatable<JsonFeedHub>
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

        #region IEquatable

        public bool Equals(JsonFeedHub other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Type == other.Type && Url == other.Url;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            return Equals((JsonFeedHub)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Type != null ? Type.GetHashCode() : 0) * 397) ^ (Url != null ? Url.GetHashCode() : 0);
            }
        }

        #endregion
    }
}