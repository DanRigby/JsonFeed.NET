using Xunit;

namespace JsonFeedNet.Tests;

public class JsonFeedSerializationTestData : TheoryData<string>
{
    public JsonFeedSerializationTestData()
    {
        Add(TestExtensions.GetResourceAsString("Simple.json").NormalizeEndings());
        Add(TestExtensions.GetResourceAsString("DaringFireballBlog.json").NormalizeEndings());
        Add(TestExtensions.GetResourceAsString("HyperCriticalBlog.json").NormalizeEndings());
        Add(TestExtensions.GetResourceAsString("MaybePizzaBlog.json").NormalizeEndings());
        Add(TestExtensions.GetResourceAsString("TheRecordPodcast.json").NormalizeEndings());
        Add(TestExtensions.GetResourceAsString("TimeTablePodcast.json").NormalizeEndings());
        Add(TestExtensions.GetResourceAsString("json_v1.1.json").NormalizeEndings());
    }
}