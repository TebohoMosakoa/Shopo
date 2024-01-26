using System.ComponentModel.DataAnnotations;

namespace PromotionApi.Models
{
    public class Product : EntityBase
    {
        public double Price { get; set; }
        public string Category { get; set; }
        public string Department { get; set; }
        public string Brand { get; set; }
        public int PromotionId { get; set; }
    }
}
