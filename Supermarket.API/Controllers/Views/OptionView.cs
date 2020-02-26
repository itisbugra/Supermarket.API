using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Supermarket.API.Controllers.Views
{
    public class OptionView
    {
        public int Id { get; set; }
        
        public string Body { get; set; }

        public string MimeType { get; set; }

        public bool IsCorrectOption { get; set; }
    }
}
