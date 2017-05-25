using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using NUnit.Framework;

namespace JsonFeedNet.Tests
{
    [TestFixture]
    public class JsonFeedTests
    {
        [Test]
        public async Task RoundtripSimple()
        {
            string inputJsonFeed = GetResourceAsString("Simple.json");
            JsonFeed jsonFeed = await JsonFeed.ParseFromStringAsync(inputJsonFeed);
            string outputJsonFeed = await jsonFeed.WriteToStringAsync();

            Assert.AreEqual(inputJsonFeed, outputJsonFeed);
        }

        [Test]
        public async Task RoundtripDaringFireballBlog()
        {
            string inputJsonFeed = GetResourceAsString("DaringFireballBlog.json");
            JsonFeed jsonFeed = await JsonFeed.ParseFromStringAsync(inputJsonFeed);
            string outputJsonFeed = await jsonFeed.WriteToStringAsync();

            Assert.AreEqual(inputJsonFeed, outputJsonFeed);
        }

        [Test]
        public async Task RoundtripHyperCriticalBlog()
        {
            string inputJsonFeed = GetResourceAsString("HyperCriticalBlog.json");
            JsonFeed jsonFeed = await JsonFeed.ParseFromStringAsync(inputJsonFeed);
            string outputJsonFeed = await jsonFeed.WriteToStringAsync();

            Assert.AreEqual(inputJsonFeed, outputJsonFeed);
        }

        [Test]
        public async Task RoundtripMaybePizzaBlog()
        {
            string inputJsonFeed = GetResourceAsString("MaybePizzaBlog.json");
            JsonFeed jsonFeed = await JsonFeed.ParseFromStringAsync(inputJsonFeed);
            string outputJsonFeed = await jsonFeed.WriteToStringAsync();

            Assert.AreEqual(inputJsonFeed, outputJsonFeed);
        }

        [Test]
        public async Task RoundtripTheRecordPodcast()
        {
            string inputJsonFeed = GetResourceAsString("TheRecordPodcast.json");
            JsonFeed jsonFeed = await JsonFeed.ParseFromStringAsync(inputJsonFeed);
            string outputJsonFeed = await jsonFeed.WriteToStringAsync();

            Assert.AreEqual(inputJsonFeed, outputJsonFeed);
        }

        [Test]
        public async Task RoundtripTimeTablePodcast()
        {
            string inputJsonFeed = GetResourceAsString("TimeTablePodcast.json");
            JsonFeed jsonFeed = await JsonFeed.ParseFromStringAsync(inputJsonFeed);
            string outputJsonFeed = await jsonFeed.WriteToStringAsync();

            Assert.AreEqual(inputJsonFeed, outputJsonFeed);
        }

        [Test]
        public async Task RoundtripJsonFeedBlogFromUri()
        {
            string feedUri = @"https://jsonfeed.org/feed.json";
            string sourceJson = await new HttpClient().GetStringAsync(feedUri);

            JsonFeed jsonFeed = await JsonFeed.ParseFromUriAsync(new Uri(feedUri));
            string outputJson = await jsonFeed.WriteToStringAsync();

            Assert.AreEqual(sourceJson, outputJson);
        }

        private static string GetResourceAsString(string resourceName)
        {
            using (var stream = GetResourceAsStream(resourceName))
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        private static Stream GetResourceAsStream(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return assembly.GetManifestResourceStream($"JsonFeedNet.Tests.Resources.{resourceName}");
        }
    }
}
