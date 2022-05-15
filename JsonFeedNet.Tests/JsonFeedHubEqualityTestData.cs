using Xunit;

namespace JsonFeedNet.Tests;

public class JsonFeedhubEqualityTestData : TheoryData<JsonFeedHub, JsonFeedHub, bool>
{
    public JsonFeedhubEqualityTestData()
    {
        Add(new JsonFeedHub
        {
            Type = "type",
            Url = "url"
        },
        new JsonFeedHub
        {
            Type = "type",
            Url = "url"
        }, true);
    }
}
