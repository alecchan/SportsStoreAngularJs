using System.Data.Entity;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Concrete
{
    public class EfDbContext : DbContext
    {
        static EfDbContext()
        {
           // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfDbContext>());
            Database.SetInitializer<EfDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<User> Users { get; set; }
    }
}