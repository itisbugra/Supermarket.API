using Supermarket.API.Domain.Models;
using System;
using System.Collections.Generic;

namespace Supermarket.API.Controllers.Views
{
    public class QuestionView
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public string MimeType { get; set; }

        public IEnumerable<OptionView> Options { get; set; }

        public DateTime InsertedAt { get; set; }
    }
}
