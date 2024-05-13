using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogApi.Models
{
	public class Product : EntityBase
	{
		public double Price { get; set; }
        public String Code { get; set; }
        public string Description { get; set; }
		public string Size { get; set; }
		public string Color { get; set; }
		public int BrandId { get; set; }
		public Brand Brand { get; set; }
		public int CategoryId { get; set; }
		public Category Category { get; set; }
		public int DepartmentId { get; set; }
		public Department Department { get; set; }
	}
}
