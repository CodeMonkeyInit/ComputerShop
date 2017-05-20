using System.Data.Entity;

namespace ComputerShop.Model
{
    public interface IComputerShopDbContext
    {
        DbSet<Finance> Financies { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Stock { get; set; }

        void SaveChanges();
    }
}