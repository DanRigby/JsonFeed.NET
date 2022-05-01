using Xunit;

namespace JsonFeedNet.Tests;

public class JsonAuthorEqualityTestData : TheoryData<JsonFeedAuthor, JsonFeedAuthor, bool>
{
    public JsonAuthorEqualityTestData()
    {
        Add(new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name",
            Url = "Url"
        }, new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name",
            Url = "Url"
        }, true);

        Add(new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name",
            Url = "Url"
        }, new JsonFeedAuthor
        {
            Avatar = string.Empty,
            Name = "Name",
            Url = "Url"
        }, false);

        Add(new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name",
            Url = "Url"
        }, new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = string.Empty,
            Url = "Url"
        }, false);

        Add(new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name",
            Url = "Url"
        }, new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name",
            Url = string.Empty
        }, false);

        Add(new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name",
            Url = "Url"
        }, new JsonFeedAuthor
        {
            Avatar = "Avatar1",
            Name = "Name",
            Url = "Url"
        }, false);

        Add(new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name",
            Url = "Url"
        }, new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name1",
            Url = "Url"
        }, false);

        Add(new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name",
            Url = "Url"
        }, new JsonFeedAuthor
        {
            Avatar = "Author",
            Name = "Name",
            Url = "Url1"
        }, false);

        Add(new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name",
            Url = "Url"
        }, new JsonFeedAuthor
        {
            Avatar = null,
            Name = "Name",
            Url = "Url"
        }, false);

        Add(new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name",
            Url = "Url"
        }, new JsonFeedAuthor
        {
            Avatar = "Author",
            Name = null,
            Url = "Url"
        }, false);

        Add(new JsonFeedAuthor
        {
            Avatar = "Avatar",
            Name = "Name",
            Url = "Url"
        }, new JsonFeedAuthor
        {
            Avatar = "Author",
            Name = "Name",
            Url = null
        }, false);
    }
}