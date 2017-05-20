using System.Data.Entity;

namespace ComputerShop.Model
{
    public class ComputerShopDbContext : DbContext, IComputerShopDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Stock { get; set; }
        public DbSet<Finance> Financies { get; set; }
    }
}
