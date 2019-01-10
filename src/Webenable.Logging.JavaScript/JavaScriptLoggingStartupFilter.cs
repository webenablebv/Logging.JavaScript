using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Webenable.Logging.JavaScript
{
    public class JavaScriptLoggingStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next) =>
            app =>
            {
                app.UseMiddleware<JavaScriptLoggingMiddleware>();
                next(app);
            };
    }
}