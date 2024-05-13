namespace Admin.Models
{
    public class PromotionProduct : EntityBase
    {
        public double Price { get; set; }
        public String Code { get; set; }
        public string Category { get; set; }
        public string Department { get; set; }
        public string Brand { get; set; }
        public int PromotionId { get; set; }
    }
}
