using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace JsonFeedNet
{
    /// <summary>
    /// An individual item in a feed.
    /// </summary>
    public class FeedItem
    {
        /// <summary>
        /// The unique identifier for the feed item.
        /// If an item is ever updated, the id should be unchanged.
        /// New items should never use a previously-used id.
        /// Ideally, the id is the full URL of the resource described by the item.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } //required

        /// <summary>
        /// The URL of the resource described by the feed item.
        /// This may be the same as the id.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; } //optional

        /// <summary>
        /// The URL of a page elsewhere.
        /// This is especially useful for linkblogs.
        /// </summary>
        [JsonProperty("external_url")]
        public string ExternalUrl { get; set; } //optional

        /// <summary>
        /// The title of the feed item.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; } //optional

        /// <summary>
        /// The content of the feed item formatted as plain HTML.
        /// This is the only field HTML is allowed in.
        /// </summary>
        [JsonProperty("content_html")]
        public string ContentHtml { get; set; } //optional

        /// <summary>
        /// The content of the feed item formatted as plain text.
        /// </summary>
        [JsonProperty("content_text")]
        public string ContentText { get; set; } //optional

        /// <summary>
        /// Plain text sentence or two describing the item.
        /// This might be presented in a timeline, for instance, where a detail view would display all of ContentHtml or ContentText.
        /// </summary>
        [JsonProperty("summary")]
        public string Summary { get; set; } //optional

        /// <summary>
        /// The URL of the main image for the item.
        /// This image may also appear in the ContentHtml — if so, it’s a hint to the feed reader that this is the main, featured image.
        /// Feed readers may use the image as a preview (probably resized as a thumbnail and placed in a timeline).
        /// </summary>
        [JsonProperty("image")]
        public string Image { get; set; } //optional

        /// <summary>
        /// The URL of an image to use as a banner.
        /// Some blogging systems (such as Medium) display a different banner image chosen to go with each post, but that image wouldn’t otherwise appear in the ContentHtml.
        /// A feed reader with a detail view may choose to show this banner image at the top of the detail view, possibly with the title overlaid.
        /// </summary>
        [JsonProperty("banner_image")]
        public string BannerImage { get; set; } //optional

        /// <summary>
        /// The date the feed item was published.
        /// </summary>
        [JsonProperty("date_published")]
        public DateTimeOffset? DatePublished { get; set; } //optional RFC 3339 format. (Example: 2010-02-07T14:04:00-05:00.)

        /// <summary>
        /// The date the feed item was modified.
        /// </summary>
        [JsonProperty("date_modified")]
        public DateTimeOffset? DateModified { get; set; } //optional RFC 3339 format. (Example: 2010-02-07T14:04:00-05:00.)

        /// <summary>
        /// Feed item author.
        /// If not specified, then the top-level author, if present, is the author of the item.
        /// </summary>
        [JsonProperty("author")]
        public Author Author { get; set; } //optional

        /// <summary>
        /// Tags associated with the feed item.
        /// Can have any plain text values you want.
        /// Tags tend to be just one word, but they may be anything.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get; set; } //optional

        /// <summary>
        /// Related resources for the feed item.
        /// Podcasts, for instance, would include an attachment that’s an audio or video file. 
        /// </summary>
        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; set; } //optional
    }
}
