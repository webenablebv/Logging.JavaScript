using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Webenable.Logging.JavaScript
{
    public class JavaScriptLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public JavaScriptLoggingMiddleware(RequestDelegate next, ILogger<JavaScriptLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/log" && context.Request.Method == "POST" && context.Request.HasFormContentType)
            {
                var form = await context.Request.ReadFormAsync();
                if (!int.TryParse(form["level"].ToString(), out var level))
                {
                    // Invalid log level specified
                    return;
                }

                var message = form["message"].ToString();
                if (!string.IsNullOrEmpty(message))
                {
                    _logger.Log((LogLevel)level, "{Url}: {Message}", form["url"], message);
                }
            }
            else
            {
                await _next(context);
            }
        }
    }
}
