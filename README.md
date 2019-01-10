# JavaScript Logging
Forwards JavaScript logs to ASP.NET Core applications.

| Windows | Linux | NuGet |
| --- | --- | --- |
| [![Windows Build status](https://ci.appveyor.com/api/projects/status/rnf0a0wpsi8td146?svg=true)](https://ci.appveyor.com/project/henkmollema/logging-javascript) | [![Linux Build Status](https://travis-ci.com/webenablebv/Logging.JavaScript.svg?branch=master)](https://travis-ci.com/webenablebv/Logging.JavaScript) | [![NuGet](https://img.shields.io/nuget/vpre/Webenable.Logging.JavaScript.svg)](https://www.nuget.org/packages/Webenable.Logging.JavaScript) |

JavaScript Logging is a small library which forwards client-side JavaScript logging via `console.info`, `console.error`, etc. to your ASP.NE Core application and calls logs the message with the equivalent using the `ILogger` interface.

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

The library will automatically inject the necessary JavaScript and register a middlware to handle the log HTTP requests.

## Dependencies
The library uses jQuery to post log messages to the server using AJAX. Please make sure that jQuery is available when using this library.

## Using the library

Any calls to the following `console` methods are intercepted and will post a log message to the server which logs the message with the corresponding log level. The default behavior of the `console` method is executed as well.

- `console.trace`
- `console.debug`
- `console.info`
- `console.warn`
- `console.error`
