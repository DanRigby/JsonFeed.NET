namespace JsonFeedNet
{
    /// <summary>
    /// A related resource to a feed.
    /// </summary>
    public class Attachment
    {
        /// <summary>
        /// The location of the attachment.
        /// </summary>
        public string Url { get; set; } //url (required)

        /// <summary>
        /// The mime type of the attachment, such as “audio/mpeg.”
        /// </summary>
        public string MimeType { get; set; } //mime_type (required)

        /// <summary>
        /// A name for the attachment.
        /// If there are multiple attachments that have the exact same title, they are considered as alternate representations of the same thing.
        /// In this way a podcaster, for instance, might provide an audio recording in different formats.
        /// </summary>
        public string Title { get; set; } //title (optional)

        /// <summary>
        /// How large the file is.
        /// </summary>
        public long SizeInBytes { get; set; } //size_in_bytes (optional)

        /// <summary>
        /// How long the attachment takes to listen to or watch.
        /// </summary>
        public long DurationInSeconds { get; set; } //duration_in_seconds (optional)
    }
}
