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
            string outputJsonFeed = jsonFeed.Serialize();

            Assert.AreEqual(inputJsonFeed, outputJsonFeed);
        }

        [Test]
        public void RoundtripDaringFireballBlog()
        {
            string inputJsonFeed = GetResourceAsString("DaringFireballBlog.json");
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Serialize();

            Assert.AreEqual(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Test]
        public void RoundtripHyperCriticalBlog()
        {
            string inputJsonFeed = GetResourceAsString("HyperCriticalBlog.json");
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Serialize();

            Assert.AreEqual(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Test]
        public void RoundtripMaybePizzaBlog()
        {
            string inputJsonFeed = GetResourceAsString("MaybePizzaBlog.json");
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Serialize();

            Assert.AreEqual(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Test]
        public void RoundtripTheRecordPodcast()
        {
            string inputJsonFeed = GetResourceAsString("TheRecordPodcast.json");
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Serialize();

            Assert.AreEqual(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Test]
        public void RoundtripTimeTablePodcast()
        {
            string inputJsonFeed = GetResourceAsString("TimeTablePodcast.json");
            JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
            string outputJsonFeed = jsonFeed.Serialize();

            Assert.AreEqual(inputJsonFeed.Length, outputJsonFeed.Length);
        }

        [Test]
        public void SerializeCreatedFeed()
        {
            var jsonFeed = new JsonFeed
            {
                Title = "Dan Rigby",
                Description = "Mobile App Development & More.",
                HomePageUrl = @"http://danrigby.com",
                FeedUrl = @"http://danrigby.com/feed.json",
                Author = new Author
                {
                    Name = "Dan Rigby",
                    Url = @"https://twitter.com/DanRigby"
                },
                Items = new List<FeedItem>
                {
                    new FeedItem
                    {
                        Id = @"http://danrigby.com/2015/09/12/inotifypropertychanged-the-net-4-6-way/",
                        Url = @"http://danrigby.com/2015/09/12/inotifypropertychanged-the-net-4-6-way/",
                        Title = "INotifyPropertyChanged, The .NET 4.6 Way",
                        ContentText = @"This would be the text of my blog post, but that would be way too verbose to put in this sample. (;",
                        DatePublished = new DateTime(2015, 09, 12)
                    }
                }
            };

            string jsonFeedString = jsonFeed.Serialize();

            Assert.IsNotEmpty(jsonFeedString);
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
