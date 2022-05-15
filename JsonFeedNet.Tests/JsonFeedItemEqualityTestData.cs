using Xunit;

namespace JsonFeedNet.Tests;

public class JsonFeedItemEqualityTestData : TheoryData<JsonFeedItem, JsonFeedItem, bool>
{
    public JsonFeedItemEqualityTestData()
    {
        DateTimeOffset dateTime = DateTimeOffset.UtcNow;
        Add(new JsonFeedItem
        {
            Id = "id",
            Url = "url",
            ExternalUrl = "externalUrl",
            Title = "title",
            ContentHtml = "contentHtml",
            ContentText = "contentText",
            Summary = "summary",
            Image = "image",
            BannerImage = "bannerImage",
            Language = "language",
            DateModified = dateTime,
            DatePublished = dateTime,
            Author = new JsonFeedAuthor
            {
                Avatar = "Avatar",
                Name = "Name",
                Url = "Url"
            },
            Authors = new List<JsonFeedAuthor>
            {
                new()
                {
                    Avatar = "Avatar",
                    Name = "Name",
                    Url = "Url"
                }
            },
            Tags = new List<string>
            {
                "tag1"
            },
            Attachments = new List<JsonFeedAttachment>
            {
                new()
                {
                    Url = "url",
                    MimeType = "mimeType",
                    Title = "title",
                    SizeInBytes = 0,
                    DurationInSeconds = 0
                }
            }
        }, new JsonFeedItem
        {
            Id = "id",
            Url = "url",
            ExternalUrl = "externalUrl",
            Title = "title",
            ContentHtml = "contentHtml",
            ContentText = "contentText",
            Summary = "summary",
            Image = "image",
            BannerImage = "bannerImage",
            Language = "language",
            DateModified = dateTime,
            DatePublished = dateTime,
            Author = new JsonFeedAuthor
            {
                Avatar = "Avatar",
                Name = "Name",
                Url = "Url"
            },
            Authors = new List<JsonFeedAuthor>
            {
                new()
                {
                    Avatar = "Avatar",
                    Name = "Name",
                    Url = "Url"
                }
            },
            Tags = new List<string>
            {
                "tag1"
            },
            Attachments = new List<JsonFeedAttachment>
            {
                new()
                {
                    Url = "url",
                    MimeType = "mimeType",
                    Title = "title",
                    SizeInBytes = 0,
                    DurationInSeconds = 0
                }
            }
        }, true);
    }
}
