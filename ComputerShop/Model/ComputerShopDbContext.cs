using System.Data.Entity;
using ComputerShop.Model.Interfaces;

namespace ComputerShop.Model
{
    public class ComputerShopDbContext : DbContext, IComputerShopDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Finance> Financies { get; set; }
    }
}
