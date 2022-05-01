// ReSharper disable ClassNeverInstantiated.Global

using System;
using Newtonsoft.Json;

namespace JsonFeedNet
{
    /// <summary>
    ///     A related resource to a feed.
    /// </summary>
    public class JsonFeedAttachment : IEquatable<JsonFeedAttachment>
    {
        /// <summary>
        ///     The location of the attachment.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; } //required

        /// <summary>
        ///     The mime type of the attachment, such as “audio/mpeg.”
        /// </summary>
        [JsonProperty("mime_type")]
        public string MimeType { get; set; } //required

        /// <summary>
        ///     A name for the attachment.
        ///     If there are multiple attachments that have the exact same title, they are considered as alternate representations
        ///     of the same thing.
        ///     In this way a podcaster, for instance, might provide an audio recording in different formats.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; } //optional

        /// <summary>
        ///     How large the file is.
        /// </summary>
        [JsonProperty("size_in_bytes")]
        public long? SizeInBytes { get; set; } //optional

        /// <summary>
        ///     How long the attachment takes to listen to or watch.
        /// </summary>
        [JsonProperty("duration_in_seconds")]
        public long? DurationInSeconds { get; set; } //optional

        #region IEquatable

        public bool Equals(JsonFeedAttachment other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Url == other.Url &&
                   MimeType == other.MimeType &&
                   Title == other.Title &&
                   SizeInBytes == other.SizeInBytes &&
                   DurationInSeconds == other.DurationInSeconds;
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

            return Equals((JsonFeedAttachment)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Url != null ? Url.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (MimeType != null ? MimeType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (Title != null ? Title.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ SizeInBytes.GetHashCode();
                hashCode = (hashCode * 397) ^ DurationInSeconds.GetHashCode();
                return hashCode;
            }
        }

        #endregion
    }
}