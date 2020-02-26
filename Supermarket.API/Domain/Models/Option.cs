using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Models
{
    public class Option
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public EMimeType MimeType { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
