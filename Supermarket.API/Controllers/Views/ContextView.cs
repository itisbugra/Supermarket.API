using System;

namespace Supermarket.API.Controllers.Views
{
    public class ContextView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public bool IsVisible { get; set; }
        
        public DateTime InsertedAt { get; set; }
    }
}
