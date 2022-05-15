// ReSharper disable StringLiteralTypo

using Xunit;

namespace JsonFeedNet.Tests;

public class JsonFeedItemTests
{
    [Theory]
    [ClassData(typeof(JsonFeedItemEqualityTestData))]
    public void JsonFeedItemEquality(JsonFeedItem a, JsonFeedItem b, bool expectedEquals)
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
}
