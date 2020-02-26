using System.ComponentModel.DataAnnotations;

namespace Supermarket.API.Controllers.Forms
{
    public class QuestionForm
    {
        [Required]
        public string Body { get; set; }

        [Required]
        public string MimeType { get; set; }
    }
}