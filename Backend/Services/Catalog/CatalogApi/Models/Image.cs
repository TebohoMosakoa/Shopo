using System.ComponentModel.DataAnnotations;

namespace CatalogApi.Models
{
	public class Image
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public int EntityID { get; set; }
	}
}
