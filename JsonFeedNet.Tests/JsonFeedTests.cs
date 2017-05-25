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
