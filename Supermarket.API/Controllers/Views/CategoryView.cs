using System;

namespace Supermarket.API.Controllers.Views
{
    public class CategoryView
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public DateTime InsertedAt { get; set; }
    }
}
