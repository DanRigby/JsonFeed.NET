// ReSharper disable StringLiteralTypo

using System.Reflection;
using Xunit;

namespace JsonFeedNet.Tests
{
    public class JsonFeedTests
    {
        [Fact]
        public void RoundtripSimple()
        {
            string inputJsonFeed = GetResourceAsString("Simple.json").NormalizeEndings();
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Write().NormalizeEndings();

            Assert.Equal(inputJsonFeed, outputJsonFeed);
        }

        [Fact]
        public void RoundtripDaringFireballBlog()
        {
            string inputJsonFeed = GetResourceAsString("DaringFireballBlog.json").NormalizeEndings();
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Write().NormalizeEndings();

            Assert.Equal(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Fact]
        public void RoundtripHyperCriticalBlog()
        {
            string inputJsonFeed = GetResourceAsString("HyperCriticalBlog.json").NormalizeEndings();
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Write().NormalizeEndings();

            Assert.Equal(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Fact]
        public void RoundtripMaybePizzaBlog()
        {
            string inputJsonFeed = GetResourceAsString("MaybePizzaBlog.json").NormalizeEndings();
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Write().NormalizeEndings();

            Assert.Equal(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Fact]
        public void RoundtripTheRecordPodcast()
        {
            string inputJsonFeed = GetResourceAsString("TheRecordPodcast.json").NormalizeEndings();
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Write().NormalizeEndings();

            Assert.Equal(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Fact]
        public void RoundtripTimeTablePodcast()
        {
            string inputJsonFeed = GetResourceAsString("TimeTablePodcast.json").NormalizeEndings();
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Write().NormalizeEndings();

            Assert.Equal(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Fact]
        public void VersionOneDotOne()
        {
            string inputJsonFeed = GetResourceAsString("json_v1.1.json").NormalizeEndings();
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Write().NormalizeEndings();

            Assert.Single(jsonFeed.Authors);
            Assert.Equal("John Gruber", jsonFeed.Authors[0].Name);
            Assert.Equal("https://twitter.com/gruber", jsonFeed.Authors[0].Url);
            Assert.Equal(48, jsonFeed.Items.Count);
            Assert.Single(jsonFeed.Items[0].Authors);
            Assert.Equal("John Gruber", jsonFeed.Items[0].Authors[0].Name);

            Assert.Equal(inputJsonFeed, outputJsonFeed);
            Assert.Equal(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Fact]
        public async Task ParseFromUri()
        {
            JsonFeed jsonFeed = await JsonFeed.ParseFromUriAsync(new Uri("https://jsonfeed.org/feed.json"));
            string outputJsonFeed = jsonFeed.Write();

            Assert.NotEmpty(outputJsonFeed);
        }

        [Fact]
        public async Task ParseFromUriWithCustomHttpMessageHandler()
        {
            JsonFeed jsonFeed = await JsonFeed.ParseFromUriAsync(new Uri("https://jsonfeed.org/feed.json"), new HttpClientHandler());
            string outputJsonFeed = jsonFeed.Write();

            Assert.NotEmpty(outputJsonFeed);
        }

        [Fact]
        public void WriteFeedToString()
        {
            JsonFeed jsonFeed = new()
            {
                Title = "Dan Rigby",
                Description = "Mobile App Development & More.",
                HomePageUrl = @"https://danrigby.com",
                FeedUrl = @"https://danrigby.com/feed.json",
                Authors = new[] {
                    new JsonFeedAuthor
                    {
                        Name = "Dan Rigby",
                        Url = @"https://twitter.com/DanRigby",
                    }
                },
                Items = new List<JsonFeedItem>
                {
                    new()
                    {
                        Id = @"https://danrigby.com/2015/09/12/inotifypropertychanged-the-net-4-6-way/",
                        Url = @"https://danrigby.com/2015/09/12/inotifypropertychanged-the-net-4-6-way/",
                        Title = "INotifyPropertyChanged, The .NET 4.6 Way",
                        ContentText = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        DatePublished = new DateTime(2015, 09, 12)
                    }
                }
            };

            string jsonFeedString = jsonFeed.Write();

            Assert.NotEmpty(jsonFeedString);
        }

        [Fact]
        public void WriteFeedToStream()
        {
            string inputJsonFeed = GetResourceAsString("Simple.json").NormalizeEndings();
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);

            using MemoryStream memoryStream = new();
            jsonFeed.Write(memoryStream);
            memoryStream.Position = 0;

            using StreamReader reader = new(memoryStream);
            string outputJsonFeed = reader.ReadToEnd().NormalizeEndings();

            Assert.Equal(inputJsonFeed, outputJsonFeed);
        }

        private static string GetResourceAsString(string resourceName)
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
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream($"JsonFeedNet.Tests.Resources.{resourceName}");
        }
    }

    public static class TestExtensions
    {
        public static string NormalizeEndings(this string value)
        {
            string result = value.Replace("\r\n", "\n").Replace("\r", "\n");
            return result;
        }
    }
}
