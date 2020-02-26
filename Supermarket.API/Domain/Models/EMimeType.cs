using System.ComponentModel;

namespace Supermarket.API.Domain.Models
{
    public enum EMimeType
    {
        [Description("text/plain")]
        PlainText = 0,

        [Description("text/markdown")]
        Markdown = 1,

        [Description("text/html")]
        Html = 2,
    }
}