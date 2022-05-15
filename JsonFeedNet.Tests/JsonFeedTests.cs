// ReSharper disable StringLiteralTypo

using JustEat.HttpClientInterception;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace JsonFeedNet.Tests;

public class JsonFeedTests
{
    [Theory]
    [ClassData(typeof(JsonFeedEqualityTestData))]
    public void JsonFeedEquality(JsonFeed a, JsonFeed b, bool expectedEquals)
    {
        if (expectedEquals)
        {
            Assert.Equal(a, b);
        }
        else
        {
            Assert.NotEqual(a, b);
        }
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
        System.Reflection.PropertyInfo[]? props = typeof(JsonFeed).GetProperties();
        foreach (System.Reflection.PropertyInfo? prop in props)
        {
            object[]? attrs = prop.GetCustomAttributes(true);
            foreach (object? attr in attrs)
            {
                if (attr is not JsonPropertyAttribute jsonProperty)
                {
                    //Continue if property doesnt have a Json Property Attribute
                    continue;
                }

                string? jsonPropertyName = jsonProperty.PropertyName;
                object? propertyValue = prop.GetValue(jsonFeed);

                if (!jObjectJsonFeed.TryGetValue(jsonPropertyName, out JToken? jToken))
                {
                    //Property not defined in json document
                    Assert.Null(propertyValue);
                    continue;
                }

                //Assert 
                object? jsonPropertyValue = jToken.ToObject(prop.PropertyType);
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
        string? inputJsonFeed = TestExtensions.GetResourceAsString("Simple.json");
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

        using DelegatingHandler? handler = options.CreateHttpMessageHandler();

        //When
        JsonFeed? jsonFeed = await JsonFeed.ParseFromUriAsync(contentUri, handler);

        //Then
        Assert.Equal(expectedJsonFeed, jsonFeed);
    }

    [Fact]
    public void WriteFeedToStream()
    {
        //Given
        string? inputJsonFeed = TestExtensions.GetResourceAsString("Simple.json").NormalizeEndings();
        var jsonFeed = JsonFeed.Parse(inputJsonFeed);

        using MemoryStream memoryStream = new();
        //When
        jsonFeed.Write(memoryStream);
        memoryStream.Position = 0;

        //Then
        using StreamReader reader = new(memoryStream);
        string? outputJsonFeed = reader.ReadToEnd().NormalizeEndings();

        Assert.Equal(inputJsonFeed, outputJsonFeed);
    }
}
