namespace Admin.Models
{
	public class EntityBase
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public virtual List<Image>? Images { get; set; }
	}
}
