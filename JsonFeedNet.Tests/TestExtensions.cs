using System.Reflection;

namespace JsonFeedNet.Tests;

public static class TestExtensions
{
    public static string NormalizeEndings(this string value)
    {
        return value.Replace("\r\n", "\n").Replace("\r", "\n");
    }

    public static string GetResourceAsString(string resourceName)
    {
        using Stream? stream = GetResourceAsStream(resourceName);
        if (stream == null)
        {
            return string.Empty;
        }

        using StreamReader reader = new(stream);
        return reader.ReadToEnd();
    }

    private static Stream? GetResourceAsStream(string resourceName)
    {
        return Assembly.GetExecutingAssembly().GetManifestResourceStream($"JsonFeedNet.Tests.Resources.{resourceName}");
    }
}
