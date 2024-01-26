using System.ComponentModel.DataAnnotations;

namespace PromotionApi.Models
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Image { get; set; }
    }
}
