// ReSharper disable StringLiteralTypo

using Xunit;

namespace JsonFeedNet.Tests;

public class JsonFeedAttachmentTests
{
    [Theory]
    [ClassData(typeof(JsonFeedAttachmentEqualityTestData))]
    public void JsonFeedAttachmentEquality(JsonFeedAttachment a, JsonFeedAttachment b, bool expectedEquals)
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
