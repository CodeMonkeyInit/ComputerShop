using ComputerShop.Model;
using System.Collections.Generic;
using System.Linq;
using ComputerShop.Model.Interfaces;

namespace ComputerShop.Controller
{
    public class ProductsController
    {
        private IEnumerable<Product> _productList;

        private readonly IComputerShopDbContext _dbContext;

        public const int ProductsOrderedSuccessfully = 1;
        
        public IEnumerable<Product> SuplierStock { get; }
        
        public ProductsController(IEnumerable<Product> suplierStock, IComputerShopDbContext dbContext)
        {
            SuplierStock = suplierStock;
            _dbContext = dbContext;
        }

        public IEnumerable<Product> ProductsList => _dbContext.Products.ToList();
                
        public void ModifyProductCount(Product product, int amount)
        {
                Product updatingProduct = _dbContext.Products.FirstOrDefault(p => p == product);

                if (updatingProduct != null)
                {
                    updatingProduct.StockAmount += amount;
                }


                _dbContext.SaveChanges();
        }

        public int OrderNewProducts(IEnumerable<Product> products)
        {
            foreach (Product product in products)
            {
                //do something
            }

            return ProductsOrderedSuccessfully;
        }
    }
}
