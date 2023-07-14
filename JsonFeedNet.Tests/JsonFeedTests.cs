namespace JsonFeedNet.Tests;

using JustEat.HttpClientInterception;
using Xunit;

public class JsonFeedTests
{
    [Fact]
    public void RoundtripSimple()
    {
        string inputJsonFeed = TestExtensions.GetResourceAsString("Simple.json").NormalizeEndings();
        JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
        string outputJsonFeed = jsonFeed.Write().NormalizeEndings();

        Assert.Equal(inputJsonFeed, outputJsonFeed);
    }

    [Fact]
    public void RoundtripDaringFireballBlog()
    {
        string inputJsonFeed = TestExtensions.GetResourceAsString("DaringFireballBlog.json").NormalizeEndings();
        JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
        string outputJsonFeed = jsonFeed.Write().NormalizeEndings();

        Assert.Equal(inputJsonFeed.Length, outputJsonFeed.Length);
    }

    [Fact]
    public void RoundtripHyperCriticalBlog()
    {
        string inputJsonFeed = TestExtensions.GetResourceAsString("HyperCriticalBlog.json").NormalizeEndings();
        JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
        string outputJsonFeed = jsonFeed.Write().NormalizeEndings();

        Assert.Equal(inputJsonFeed.Length, outputJsonFeed.Length);
    }

    [Fact]
    public void RoundtripMaybePizzaBlog()
    {
        string inputJsonFeed = TestExtensions.GetResourceAsString("MaybePizzaBlog.json").NormalizeEndings();
        JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
        string outputJsonFeed = jsonFeed.Write().NormalizeEndings();

        Assert.Equal(inputJsonFeed.Length, outputJsonFeed.Length);
    }

    [Fact]
    public void RoundtripTheRecordPodcast()
    {
        string inputJsonFeed = TestExtensions.GetResourceAsString("TheRecordPodcast.json").NormalizeEndings();
        JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
        string outputJsonFeed = jsonFeed.Write().NormalizeEndings();

        Assert.Equal(inputJsonFeed.Length, outputJsonFeed.Length);
    }

    [Fact]
    public void RoundtripTimeTablePodcast()
    {
        string inputJsonFeed = TestExtensions.GetResourceAsString("TimeTablePodcast.json").NormalizeEndings();
        JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
        string outputJsonFeed = jsonFeed.Write().NormalizeEndings();

        Assert.Equal(inputJsonFeed.Length, outputJsonFeed.Length);
    }

    [Fact]
    public void VersionOneDotOne()
    {
        string inputJsonFeed = TestExtensions.GetResourceAsString("json_v1.1.json").NormalizeEndings();
        JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
        string outputJsonFeed = jsonFeed.Write().NormalizeEndings();

        Assert.Single(jsonFeed.Authors);
        Assert.Equal("John Gruber", jsonFeed.Authors[0].Name);
        Assert.Equal("https://twitter.com/gruber", jsonFeed.Authors[0].Url);
        Assert.Equal(48, jsonFeed.Items.Count);
        Assert.Single(jsonFeed.Items[0].Authors);
        Assert.Equal("John Gruber", jsonFeed.Items[0].Authors[0].Name);

        Assert.Equal(inputJsonFeed, outputJsonFeed);
        Assert.Equal(inputJsonFeed.Length, outputJsonFeed.Length);
    }

    [Fact]
    public async Task ParseFromUriAsyncMakesNetworkRequestAndDeserializesOutput()
    {
        //Given
        string inputJsonFeed = TestExtensions.GetResourceAsString("Simple.json");
        var contentUri = new Uri("https://jsonfeed.org/feed.json");
        var options = new HttpClientInterceptorOptions();
        var builder = new HttpRequestInterceptionBuilder();

        builder
            .Requests()
            .ForGet()
            .ForHttps()
            .ForHost("jsonfeed.org")
            .ForUri(contentUri)
            .Responds()
            .WithContent(inputJsonFeed)
            .RegisterWith(options);

        using DelegatingHandler handler = options.CreateHttpMessageHandler();

        //When
        JsonFeed? jsonFeed = await JsonFeed.ParseFromUriAsync(contentUri, handler);

        //Then
        Assert.Equal(inputJsonFeed.NormalizeEndings(), jsonFeed.Write().NormalizeEndings());
    }

    [Fact]
    public void WriteFeedToString()
    {
        JsonFeed jsonFeed = new()
        {
            Title = "Dan Rigby",
            Description = "Mobile App Development & More.",
            HomePageUrl = "https://danrigby.com",
            FeedUrl = "https://danrigby.com/feed.json",
            Authors = new List<JsonFeedAuthor>{
                new()
                {
                    Name = "Dan Rigby",
                    Url = "https://twitter.com/DanRigby"
                }
            },
            Items = new List<JsonFeedItem>
            {
                new()
                {
                    Id = "https://danrigby.com/2015/09/12/inotifypropertychanged-the-net-4-6-way/",
                    Url = "https://danrigby.com/2015/09/12/inotifypropertychanged-the-net-4-6-way/",
                    Title = "INotifyPropertyChanged, The .NET 4.6 Way",
                    ContentText = "With the release of Visual Studio 2015 & .NET 4.6, we have a new version of the C# compiler and along with it a new version of C# [version 6] that includes new language features that we can leverage to improve the implementation of INotifyPropertyChanged in our applications.",
                    DatePublished = new DateTime(2015, 09, 12)
                }
            }
        };

        string jsonFeedString = jsonFeed.Write();

        Assert.NotEmpty(jsonFeedString);
    }

    [Fact]
    public void WriteFeedToStream()
    {
        //Given
        string inputJsonFeed = TestExtensions.GetResourceAsString("Simple.json").NormalizeEndings();
        var jsonFeed = JsonFeed.Parse(inputJsonFeed);

        using MemoryStream memoryStream = new();
        //When
        jsonFeed.Write(memoryStream);
        memoryStream.Position = 0;

        //Then
        using StreamReader reader = new(memoryStream);
        string outputJsonFeed = reader.ReadToEnd().NormalizeEndings();

        Assert.Equal(inputJsonFeed, outputJsonFeed);
    }
}
