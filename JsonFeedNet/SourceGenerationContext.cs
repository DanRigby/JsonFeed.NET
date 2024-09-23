using System.Text.Json.Serialization;

namespace JsonFeedNet;

[JsonSourceGenerationOptions(
    WriteIndented = true,
    PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
    GenerationMode = JsonSourceGenerationMode.Metadata,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull | JsonIgnoreCondition.WhenWritingDefault)]
[JsonSerializable(typeof(JsonFeed))]
[JsonSerializable(typeof(JsonFeedAttachment))]
[JsonSerializable(typeof(JsonFeedAuthor))]
[JsonSerializable(typeof(JsonFeedHub))]
[JsonSerializable(typeof(JsonFeedItem))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}
