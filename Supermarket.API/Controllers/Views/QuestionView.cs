using Supermarket.API.Domain.Models;

namespace Supermarket.API.Controllers.Views
{
    public class QuestionView
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public string MimeType { get; set; }
    }
}
