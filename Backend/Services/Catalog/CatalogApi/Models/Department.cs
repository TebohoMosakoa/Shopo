namespace CatalogApi.Models
{
	public class Department : EntityBase
	{
        public List<Product> Products { get; set; }
    }
}
