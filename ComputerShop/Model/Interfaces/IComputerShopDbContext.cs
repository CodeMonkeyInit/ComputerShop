using System.Data.Entity;

namespace ComputerShop.Model.Interfaces
{
    public interface IComputerShopDbContext
    {
        DbSet<Finance> Financies { get; }
        DbSet<Order> Orders { get;  }
        DbSet<Product> Products { get; }

        int SaveChanges();
    }
}