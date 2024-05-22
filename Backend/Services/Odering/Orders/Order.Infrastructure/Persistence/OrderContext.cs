using Microsoft.EntityFrameworkCore;
using Order.Domain.Common;
using Order.Domain.Models;

namespace Order.Infrastructure.Persistence
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<UserOrder> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserOrder>().HasData(
                new UserOrder() { Id = 1, UserName = "admin", FirstName = "Teboho", LastName = "Mosakoa", EmailAddress = "mosakoat@mail.com", DateCreated = DateTime.Now, CreatedBy = "admin", DateModified = DateTime.Now, ModifiedBy = "admin", AddressLine = "Bahcelievler", Surburb = "Willowbrook", City = "Roodepoort", Province = "Gauteng", ZipCode = "1724", TotalPrice = 350, CardName = "ABCD", CardNumber = "12345", Expiration = "2000", PaymentMethod = 1, Name = "mosakoat@mail.com", CVV = "123" }
            );
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<EntityBase>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.DateCreated = DateTime.Now;
                        entry.Entity.CreatedBy = "admin";
                        break;
                    case EntityState.Modified:
                        entry.Entity.DateModified = DateTime.Now;
                        entry.Entity.ModifiedBy = "admin";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
