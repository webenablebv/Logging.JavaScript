using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.DependencyInjection;

namespace Webenable.Logging.JavaScript
{
    public static class ServiceCollectionExtensions
    {
        public static void AddJavaScriptLogging(this IServiceCollection services)
        {
            services.AddTransient<ITagHelperComponent, JavaScriptLoggingTagHelperComponent>();
            services.AddSingleton<IStartupFilter, JavaScriptLoggingStartupFilter>();
        }
    }
}