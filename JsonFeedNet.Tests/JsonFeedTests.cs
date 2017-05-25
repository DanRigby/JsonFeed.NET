using System;
using System.Collections.Generic;
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
        public void RoundtripSimple()
        {
            string inputJsonFeed = GetResourceAsString("Simple.json");
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Write();

            Assert.AreEqual(inputJsonFeed, outputJsonFeed);
        }

        [Test]
        public void RoundtripDaringFireballBlog()
        {
            string inputJsonFeed = GetResourceAsString("DaringFireballBlog.json");
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Write();

            Assert.AreEqual(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Test]
        public void RoundtripHyperCriticalBlog()
        {
            string inputJsonFeed = GetResourceAsString("HyperCriticalBlog.json");
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Write();

            Assert.AreEqual(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Test]
        public void RoundtripMaybePizzaBlog()
        {
            string inputJsonFeed = GetResourceAsString("MaybePizzaBlog.json");
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Write();

            Assert.AreEqual(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Test]
        public void RoundtripTheRecordPodcast()
        {
            string inputJsonFeed = GetResourceAsString("TheRecordPodcast.json");
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Write();

            Assert.AreEqual(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Test]
        public void RoundtripTimeTablePodcast()
        {
            string inputJsonFeed = GetResourceAsString("TimeTablePodcast.json");
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Write();

            Assert.AreEqual(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Test]
        public async Task ParseFromUri()
        {
            JsonFeed jsonFeed = await JsonFeed.ParseFromUriAsync(new Uri("https://jsonfeed.org/feed.json"));
            string outputJsonFeed = jsonFeed.Write();

            Assert.IsNotEmpty(outputJsonFeed);
        }

        [Test]
        public async Task ParseFromUriWithCustomHttpMessageHandler()
        {
            JsonFeed jsonFeed = await JsonFeed.ParseFromUriAsync(new Uri("https://jsonfeed.org/feed.json"), new HttpClientHandler());
            string outputJsonFeed = jsonFeed.Write();

            Assert.IsNotEmpty(outputJsonFeed);
        }

        [Test]
        public void WriteFeedToString()
        {
            var jsonFeed = new JsonFeed
            {
                Title = "Dan Rigby",
                Description = "Mobile App Development & More.",
                HomePageUrl = @"http://danrigby.com",
                FeedUrl = @"http://danrigby.com/feed.json",
                Author = new JsonFeedAuthor
                {
                    Name = "Dan Rigby",
                    Url = @"https://twitter.com/DanRigby",
                },
                Items = new List<JsonFeedItem>
                {
                    new JsonFeedItem
                    {
                        Id = @"http://danrigby.com/2015/09/12/inotifypropertychanged-the-net-4-6-way/",
                        Url = @"http://danrigby.com/2015/09/12/inotifypropertychanged-the-net-4-6-way/",
                        Title = "INotifyPropertyChanged, The .NET 4.6 Way",
                        ContentText = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                        DatePublished = new DateTime(2015, 09, 12)
                    }
                }
            };

            string jsonFeedString = jsonFeed.Write();

            Assert.IsNotEmpty(jsonFeedString);
        }

        [Test]
        public void WriteFeedToStream()
        {
            string inputJsonFeed = GetResourceAsString("Simple.json");
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);

            using (var memoryStream = new MemoryStream())
            {
                jsonFeed.Write(memoryStream);
                memoryStream.Position = 0;

                using (var reader = new StreamReader(memoryStream))
                {
                    string outputJsonFeed = reader.ReadToEnd();
                    Assert.AreEqual(inputJsonFeed, outputJsonFeed);
                }
            }
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
