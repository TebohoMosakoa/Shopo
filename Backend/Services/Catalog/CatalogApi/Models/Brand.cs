namespace CatalogApi.Models
{
	public class Brand : EntityBase
	{
        public List<Product>? Products { get; set; }
    }
}
