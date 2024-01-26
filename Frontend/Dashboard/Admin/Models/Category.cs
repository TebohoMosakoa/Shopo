namespace Admin.Models
{
	public class Category : EntityBase
	{
        public List<Product>? Products { get; set; }
    }
}
