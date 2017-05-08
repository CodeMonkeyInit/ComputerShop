using ComputerShop.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Controller
{
    class ProductsController
    {
        private IEnumerable<Product> productList;

        private IEnumerable<Product> SuplierStock => new SuplierProducts().Products;

        public IEnumerable<Product> GetProductList()
        {
            if (productList == null)
            {
                using (var dbContext = new ComputerShopDbContext())
                {
                    productList = dbContext.Stock.ToList();
                }
            }

            return productList;
        }

        public void ModifyProductCount(Product product, int amount)
        {
            using (var dbContext = new ComputerShopDbContext())
            {
                Product updatingProduct = dbContext.Stock.FirstOrDefault(p => p == product);

                updatingProduct.StockAmount += amount;
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
