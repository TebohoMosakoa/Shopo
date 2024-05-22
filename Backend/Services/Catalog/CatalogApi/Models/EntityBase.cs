using System.ComponentModel.DataAnnotations;

namespace CatalogApi.Models
{
	public class EntityBase
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Image4 { get; set; }
    }
}
