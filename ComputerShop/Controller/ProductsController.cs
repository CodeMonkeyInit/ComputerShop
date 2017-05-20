using ComputerShop.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Controller
{
    public class ProductsController
    {
        private IEnumerable<Product> _productList;

        private readonly IComputerShopDbContext _dbContext;
        
        public IEnumerable<Product> SuplierStock { get; }
        
        public ProductsController(IEnumerable<Product> suplierStock, IComputerShopDbContext dbContext)
        {
            SuplierStock = suplierStock;
            _dbContext = dbContext;
        }

        public IEnumerable<Product> ProductsList => _dbContext.Stock.ToList();
                
        public void ModifyProductCount(Product product, int amount)
        {
            using (var dbContext = new ComputerShopDbContext())
            {
                Product updatingProduct = dbContext.Stock.FirstOrDefault(p => p == product);

                if (updatingProduct != null)
                {
                    updatingProduct.StockAmount += amount;
                }

                dbContext.SaveChanges();
            }
        }

        public void OrderNewProducts(IEnumerable<Product> products)
        {
            foreach (Product product in products)
            {
                //do something
            }
        }
    }
}
