# Neutrino.Seyren

A .Net client for the Seyren alerting platform

[![NuGet version](https://buildstats.info/nuget/Neutrino.Seyren?includePreReleases=false)](http://www.nuget.org/packages/Neutrino.Seyren/)

## Introduction

Seyren is an alerting dashboard for graphite which supports many different notification channels.

Checks and subscriptions are managed via the [Seyren API](https://github.com/scobal/seyren/blob/master/API.md). 

This library provides a .Net implementation of that API targetting .NET Standard 1.3 and later.

### Installation

To install the library from [Nuget](https://nuget.org) using the .NET SDK run:

```
dotnet add package Neutrino.Seyren
```

## Basic Examples

### Creating Checks

```c#
var client = new SeyrenClient(new HttpClient
{
    BaseAddress = new Uri("http://localhost:8080")
});

Check newCheck = await client.Checks.CreateAsync(new Check
{
    Name = "My CPU Check",
    Description = "Make sure my CPU is not catching fire.",
    Target = "movingMedian(stats.gauges.server_001.cpu, '5m')",
    Warn = 60,
    Error = 80,
    Enabled = true,
    From = "0000",
    Until = "2359"
});

Console.WriteLine(newCheck.Id);
```

### Adding Subscriptions

```c#
var client = new SeyrenClient(new HttpClient
{
    BaseAddress = new Uri("http://localhost:8080")
});

Subscription subscription = await client.Subscriptions.Create(checkId, new Subscription
{
    Target = "test@gmail.com",
    Type = SubscriptionType.Email,
    IgnoreWarn = false,
    IgnoreError = false,
    IgnoreOk = false,
    FromTime = "0800",
    ToTime = "1700",
    EnabledOnMonday = true,
    EnabledOnTuesday = true,
    EnabledOnWednesday = true,
    EnabledOnThursday = true,
    EnabledOnFriday = true
});

Console.WriteLine(subscription.Id);
```

### Getting Alerts

```c#
var client = new SeyrenClient(new HttpClient
{
    BaseAddress = new Uri("http://localhost:8080")
});

SeyrenResponse<Alert> alerts = await client.Alerts.GetByCheckId(checkId);

foreach ( Alert alert in alerts.Values )
{
    Console.WriteLine($"[{alert.Timestamp:o}] {alert.Target} {Enum.GetName(typeof(AlertType), alert.ToType)}");
}
```

## Feedback

Any feedback or issues can be added to the issues for this project in [GitHub](https://https://github.com/uatec/Neutrino.Seyren/issues).

## Repository

The repository is hosted at [https://github.com/uatec/Neutrino.Seyren](https://github.com/uatec/Neutrino.Seyren)

## Contributing

[![Build status](https://ci.appveyor.com/api/projects/status/jvrg4gp45o1ami4k/branch/master?svg=true)](https://ci.appveyor.com/project/uatec/neutrino-seyren/branch/master)

Compiling the library yourself requires Git and the [.NET Core SDK](https://www.microsoft.com/net/download/core) to be installed (version 2.0.0 or later).

To build and test the library locally from a terminal/command-line, run the following set of commands:

```
git clone https://github.com/uatec/Neutrino.Seyren.git
cd Neutrino.Seyren
dotnet build
dotnet test
```

## Licence

This project is licenced under the [Apache 2.0](http://www.apache.org/licenses/LICENSE-2.0.html) license.