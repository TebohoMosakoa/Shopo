namespace Admin.Models
{
    public class Promotion : EntityBase
    {
        public string Description { get; set; }
        public string Code { get; set; }
        public int Amount { get; set; }
        public List<Product>? Products { get; set; }
    }
}
