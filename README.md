JsonFeed.NET v0.1.0-alpha
==============

JsonFeed.NET is a portable .NET library for generating and consuming [JSON Feed](https://jsonfeed.org/) compliant site feeds.

 [![NuGet Pre Release](https://img.shields.io/nuget/vpre/JsonFeed.NET.svg?style=plastic)](https://www.nuget.org/packages/JsonFeed.NET) [![Twitter Follow](https://img.shields.io/twitter/follow/DanRigby.svg?style=plastic)](https://twitter.com/DanRigby)

#### Supported platforms
* .NET Framework 4.5.1+
* .NET Core 1.1+
* Mono
* UWP
* Xamarin.iOS
* Xamarin.Android

## How To Install

`Install-Package JsonFeed.NET -Pre`

## Sample Usage

#### Parsing a JsonFeed from a string
```csharp
JsonFeed jsonFeed = JsonFeed.Parse(jsonFeedString);
```

#### Parsing a JsonFeed from a Url
```csharp
JsonFeed jsonFeed = await JsonFeed.ParseFromUriAsync(new Uri(@"https://jsonfeed.org/feed.json"));
```

#### Creating a new JsonFeed and serializing it to a string

```csharp
var jsonFeed = new JsonFeed
{
    Version = @"https://jsonfeed.org/version/1",
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
```

## License

Copyright (c) 2017 Dan Rigby

Licensed under the [MIT license](https://github.com/DanRigby/JsonFeed.Net/blob/master/LICENSE).
