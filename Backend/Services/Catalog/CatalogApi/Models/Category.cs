namespace CatalogApi.Models
{
	public class Category : EntityBase
	{
        public List<Product> Products { get; set; }
    }
}
