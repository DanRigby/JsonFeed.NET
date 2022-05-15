// ReSharper disable StringLiteralTypo

using Xunit;

namespace JsonFeedNet.Tests;

public class JsonAuthorTests
{
    [Theory]
    [ClassData(typeof(JsonAuthorEqualityTestData))]
    public void JsonAuthorEquality(JsonFeedAuthor a, JsonFeedAuthor b, bool expectedEquals)
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
