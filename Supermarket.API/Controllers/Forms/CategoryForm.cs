namespace Supermarket.API.Controllers.Forms
{
    public class CategoryForm
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int? ParentCategoryId { get; set; }
    }
}
