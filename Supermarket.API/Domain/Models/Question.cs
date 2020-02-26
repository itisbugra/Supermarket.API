using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Domain.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Body { get; set; }

        public EMimeType MimeType { get; set; }

        public IList<Option> Options { get; set; } = new List<Option>();

        public DateTime InsertedAt { get; set; }
    }
}
