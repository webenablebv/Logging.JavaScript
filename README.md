# JavaScript Logging
Forwards JavaScript console logs to ASP.NET Core applications.

| Windows | Linux | NuGet |
| --- | --- | --- |
| [![Windows Build status](https://ci.appveyor.com/api/projects/status/rnf0a0wpsi8td146?svg=true)](https://ci.appveyor.com/project/henkmollema/logging-javascript) | [![Linux Build Status](https://travis-ci.com/webenablebv/Logging.JavaScript.svg?branch=master)](https://travis-ci.com/webenablebv/Logging.JavaScript) | [![NuGet](https://img.shields.io/nuget/vpre/Webenable.Logging.JavaScript.svg)](https://www.nuget.org/packages/Webenable.Logging.JavaScript) |

JavaScript Logging is a small library which forwards client-side JavaScript logging via `console.info`, `console.error`, etc. to your ASP.NE Core application and logs the message with the equivalent log level using the `ILogger` interface. This library is inspired by the [blogpost](http://hishambinateya.com/integrate-javascript-logging-with-asp.net-core-logging-apis) and [sample application](https://github.com/hishamco/jsLogger) of Hisham and I took the liberty to create a NuGet package from his idea.

## Getting started

Install the package from NuGet:

```
dotnet add package Webenable.Logging.JavaScript
```

Configure the logging library in your Startup class:

```cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddJavaScriptLogging();

    // ...
}
```

The library will automatically inject the necessary JavaScript and register a middleware to handle the logging HTTP requests.

## Dependencies
The library uses jQuery to post log messages to your application using AJAX. Please make sure that jQuery is available when using this library.

## Using the library

Any calls to the following `console` methods are intercepted and will post a log message to the server which logs the message with the corresponding log level. The default behavior of the `console` method is executed as well.

- `console.trace`
- `console.debug`
- `console.info`
- `console.warn`
- `console.error`

Please note that the `console.log` method is _not_ intercepted.
