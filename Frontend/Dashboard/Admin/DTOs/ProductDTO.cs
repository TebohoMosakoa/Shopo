using Admin.Models;

namespace Admin.DTOs
{
    public class ProductDTO : EntityBase
    {
        public double Price { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string Code { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public int DepartmentId { get; set; }
    }
}
