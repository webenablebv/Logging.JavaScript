using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Webenable.Logging.JavaScript
{
    public class JavaScriptLoggingTagHelperComponent : TagHelperComponent
    {
        public override int Order => -1;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.Equals(context.TagName, "body", StringComparison.OrdinalIgnoreCase))
            {
                output.PostContent.AppendHtml(Resources.JavaScriptSnippet + Environment.NewLine);
            }
        }
    }
}
