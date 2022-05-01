using Xunit;

namespace JsonFeedNet.Tests;

public class JsonFeedAttachmentEqualityTestData : TheoryData<JsonFeedAttachment, JsonFeedAttachment, bool>
{
    public JsonFeedAttachmentEqualityTestData()
    {
        Add(new JsonFeedAttachment
            {
                Url = "url",
                MimeType = "mimeType",
                Title = "title",
                SizeInBytes = 0,
                DurationInSeconds = 0
            },
            new JsonFeedAttachment
            {
                Url = "url",
                MimeType = "mimeType",
                Title = "title",
                SizeInBytes = 0,
                DurationInSeconds = 0
            }, true);
    }
}