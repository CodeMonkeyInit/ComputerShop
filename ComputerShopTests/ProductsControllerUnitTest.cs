using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShop.Controller;
using ComputerShop.Model;
using ComputerShopTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerShopTests
{
    [TestClass]
    public class ProductsControllerUnitTest
    {
        private readonly ComputerShopDbContextMock _computerShopDbContext;
        private readonly ProductsController _productsController;

        public ProductsControllerUnitTest()
        {
            _computerShopDbContext = new ComputerShopDbContextMock();
            _productsController = new ProductsController(_computerShopDbContext.Products , _computerShopDbContext);
        }

        [TestMethod]
        public void ModifyProductCount()
        {
            const int amountAdjustment = -5;

            Product product = _computerShopDbContext.Products.FirstOrDefault();
            int amount = product.StockAmount;

            int expectedAmount = amount + amountAdjustment;

            _productsController.ModifyProductCount(product, amountAdjustment);

            Assert.AreEqual(expectedAmount, product.StockAmount);
        }

        [TestMethod]
        public void OrderNewProducts()
        {
            var orderNewProductsResult = _productsController.OrderNewProducts(_computerShopDbContext.Products);

            Assert.AreEqual(orderNewProductsResult, ProductsController.ProductsOrderedSuccessfully);
        }
    }
}
