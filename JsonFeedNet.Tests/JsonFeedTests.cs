// ReSharper disable StringLiteralTypo

using JustEat.HttpClientInterception;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace JsonFeedNet.Tests;

public class JsonFeedTests
{
    [Fact]
    public void JsonFeedAuthorEquality()
    {
        //Given
        var author1 = new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name",
            Url = "Url"
        };

        var author2 = new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name",
            Url = "Url"
        };

        //When


        //Then
    }

    [Theory]
    [ClassData(typeof(JsonFeedSerializationTestData))]
    public void JsonFeedParseDeserializesDocumentCorrectly(string inputJsonFeed)
    {
        //Given
        var jObjectJsonFeed = JObject.Parse(inputJsonFeed);

        //When
        var jsonFeed = JsonFeed.Parse(inputJsonFeed);

        //Then
        var props = typeof(JsonFeed).GetProperties();
        foreach (var prop in props)
        {
            var attrs = prop.GetCustomAttributes(true);
            foreach (var attr in attrs)
            {
                var jsonProperty = attr as JsonPropertyAttribute;
                if (jsonProperty == null)
                {
                    //Continue if property doesnt have a Json Property Attribute
                    continue;
                }

                var jsonPropertyName = jsonProperty.PropertyName;
                var propertyValue = prop.GetValue(jsonFeed);

                if (!jObjectJsonFeed.TryGetValue(jsonPropertyName, out var jToken))
                {
                    //Property not defined in json document
                    Assert.Null(propertyValue);
                    continue;
                }

                //Assert 
                var jsonPropertyValue = jToken.ToObject(prop.PropertyType);
                switch (jsonPropertyValue)
                {
                    case List<JsonFeedAuthor> authors:
                        Assert.Equal(authors, propertyValue as List<JsonFeedAuthor>);
                        break;
                    case List<JsonFeedItem> feedItems:
                        Assert.Equal(feedItems, propertyValue as List<JsonFeedItem>);
                        break;
                    case List<JsonFeedHub> feedHubs:
                        Assert.Equal(feedHubs, propertyValue as List<JsonFeedHub>);
                        break;
                    default:
                        Assert.Equal(jsonPropertyValue, propertyValue);
                        break;
                }
            }
        }
    }

    [Fact]
    public async Task ParseFromUriAsyncMakesNetworkRequestAndDeserializesOutput()
    {
        //Given
        var inputJsonFeed = TestExtensions.GetResourceAsString("Simple.json");
        var expectedJsonFeed = JsonFeed.Parse(inputJsonFeed);
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

        using var client = options.CreateHttpClient();

        //When
        var jsonFeed = await client.ParseFromUriAsync(contentUri);

        //Then
        Assert.Equal(expectedJsonFeed, jsonFeed);
    }

    [Fact]
    public void WriteFeedToStream()
    {
        //Given
        var inputJsonFeed = TestExtensions.GetResourceAsString("Simple.json").NormalizeEndings();
        var jsonFeed = JsonFeed.Parse(inputJsonFeed);

        using MemoryStream memoryStream = new();
        //When
        jsonFeed.Write(memoryStream);
        memoryStream.Position = 0;

        //Then
        using StreamReader reader = new(memoryStream);
        var outputJsonFeed = reader.ReadToEnd().NormalizeEndings();

        Assert.Equal(inputJsonFeed, outputJsonFeed);
    }
}