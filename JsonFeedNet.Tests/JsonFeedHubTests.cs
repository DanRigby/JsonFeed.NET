// ReSharper disable StringLiteralTypo

using Xunit;

namespace JsonFeedNet.Tests;

public class JsonFeedHubTests
{
    [Theory]
    [ClassData(typeof(JsonFeedhubEqualityTestData))]
    public void JsonFeedHubEqualityTests(JsonFeedHub a, JsonFeedHub b, bool expectedEquals)
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