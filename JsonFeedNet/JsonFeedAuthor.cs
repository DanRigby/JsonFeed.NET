using System;
using Newtonsoft.Json;

namespace JsonFeedNet
{
    /// <summary>
    ///     A feed author.
    /// </summary>
    public class JsonFeedAuthor : IEquatable<JsonFeedAuthor>
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

        #region IEquatable

        public bool Equals(JsonFeedAuthor other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Name == other.Name && Url == other.Url && Avatar == other.Avatar;
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

            return Equals((JsonFeedAuthor)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Name != null ? Name.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (Url != null ? Url.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Avatar != null ? Avatar.GetHashCode() : 0);
                return hashCode;
            }
        }

        #endregion
    }
}