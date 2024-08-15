namespace MVC.WebApp.Models
{
    public class CategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }

    public class CategoryUpsertDto
    {
        public string CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
