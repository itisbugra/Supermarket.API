using System;
using System.Collections.Generic;

namespace Supermarket.API.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }

        public DateTime InsertedAt { get; set; }

        public Category ParentCategory { get; set; }

        public IList<Category> Categories { get; set; } = new List<Category>();
    }
}
