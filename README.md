JsonFeed.NET
==============

JsonFeed.NET is a portable .NET library for generating and consuming [JSON Feed](https://jsonfeed.org/) compliant site feeds.

[![Build](https://github.com/DanRigby/JsonFeed.NET/actions/workflows/build.yml/badge.svg)](https://github.com/DanRigby/JsonFeed.NET/actions/workflows/build.yml) [![NuGet Pre Release](https://img.shields.io/nuget/vpre/JsonFeed.NET.svg)](https://www.nuget.org/packages/JsonFeed.NET) [![Twitter Follow](https://img.shields.io/twitter/follow/DanRigby.svg)](https://twitter.com/DanRigby)

#### Supported platforms
* .NET Framework 4.5.1+
* .NET Core 1.1+
* Mono
* UWP
* Xamarin.iOS
* Xamarin.Android

## How To Install

`Install-Package JsonFeed.NET`

## Sample Usage

#### Parsing a JsonFeed from a string
```csharp
JsonFeed jsonFeed = JsonFeed.Parse(jsonFeedString);
```

#### Parsing a JsonFeed from a Url
```csharp
JsonFeed jsonFeed = await JsonFeed.ParseFromUriAsync(new Uri("https://jsonfeed.org/feed.json"));
```

#### Parsing a JsonFeed from a Url using a custom HttpMessageHandler
```csharp
JsonFeed jsonFeed = await JsonFeed.ParseFromUriAsync(new Uri("https://jsonfeed.org/feed.json"), new HttpClientHandler());
```

#### Creating a new JsonFeed and writing it to a string

```csharp
var jsonFeed = new JsonFeed
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
        new JsonFeedItem
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
```

#### Writing a JsonFeed to a stream

```csharp
JsonFeed jsonFeed = JsonFeed.Parse(inputJsonFeed);
jsonFeed.Write(stream);
```

## License

Copyright (c) 2023 Dan Rigby

Licensed under the [MIT license](https://github.com/DanRigby/JsonFeed.Net/blob/master/LICENSE).
