using System.ComponentModel.DataAnnotations;

namespace CatalogApi.Models
{
	public class EntityBase
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
		public virtual List<Image> Images { get; set; }
	}
}
