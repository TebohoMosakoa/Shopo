using Microsoft.EntityFrameworkCore;
using PromotionApi.Models;

namespace PromotionApi.Data
{
    public class PromotionContext : DbContext
    {
        public PromotionContext(DbContextOptions<PromotionContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
    }
}
