using Xunit;

namespace JsonFeedNet.Tests;

public class JsonFeedEqualityTestData : TheoryData<JsonFeed, JsonFeed, bool>
{
    public JsonFeedEqualityTestData()
    {
        var dateTime = DateTimeOffset.UtcNow;
        Add(new JsonFeed
        {
            Version = "version",
            Title = "title",
            HomePageUrl = "homepageurl",
            FeedUrl = "feedurl",
            Description = "description",
            UserComment = "userComment",
            Icon = "icon",
            FavIcon = "favicon",
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
                    Avatar = "Avatar1",
                    Name = "Name1",
                    Url = "Url1"
                }
            },
            Language = "language",
            Expired = false,
            Hubs = new List<JsonFeedHub>
            {
                new()
                {
                    Type = "type",
                    Url = "url"
                }
            },
            Items = new List<JsonFeedItem>
            {
                new()
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
                    DatePublished =dateTime,
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
                }
            }
        }, new JsonFeed
        {
            Version = "version",
            Title = "title",
            HomePageUrl = "homepageurl",
            FeedUrl = "feedurl",
            Description = "description",
            UserComment = "userComment",
            Icon = "icon",
            FavIcon = "favicon",
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
                    Avatar = "Avatar1",
                    Name = "Name1",
                    Url = "Url1"
                }
            },
            Language = "language",
            Expired = false,
            Hubs = new List<JsonFeedHub>
            {
                new()
                {
                    Type = "type",
                    Url = "url"
                }
            },
            Items = new List<JsonFeedItem>
            {
                new()
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
                    DatePublished =dateTime,
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
                }
            }
        }, true);
    }
}