﻿namespace JsonFeedNet;

using System.Text.Json.Serialization;

/// <summary>
///     A related resource to a feed.
/// </summary>
public class JsonFeedAttachment
{
    /// <summary>
    ///     The location of the attachment.
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; } //required

    /// <summary>
    ///     The mime type of the attachment, such as “audio/mpeg.”
    /// </summary>
    [JsonPropertyName("mime_type")]
    public string MimeType { get; set; } //required

    /// <summary>
    ///     A name for the attachment.
    ///     If there are multiple attachments that have the exact same title, they are considered as alternate representations
    ///     of the same thing.
    ///     In this way a podcaster, for instance, might provide an audio recording in different formats.
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; } //optional

    /// <summary>
    ///     How large the file is.
    /// </summary>
    [JsonPropertyName("size_in_bytes")]
    public long? SizeInBytes { get; set; } //optional

    /// <summary>
    ///     How long the attachment takes to listen to or watch.
    /// </summary>
    [JsonPropertyName("duration_in_seconds")]
    public long? DurationInSeconds { get; set; } //optional
}
