using System;
using System.Collections.Generic;
using System.Linq;
using ComputerShop.Controller;
using ComputerShop.Model;
using ComputerShop.Model.Interfaces;
using ComputerShopTests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComputerShopTests
{
    [TestClass]
    public class OrdersControllerUnitTest
    {
        private readonly ComputerShopDbContextMock _computerShopDbContext;
        private readonly OrdersController _ordersController;

        
        public OrdersControllerUnitTest()
        {
            _computerShopDbContext = new ComputerShopDbContextMock();
            _ordersController = new OrdersController(_computerShopDbContext);
        }

        [TestMethod]
        public void GetProductAmountSold()
        {
            Product product = _computerShopDbContext.Products
                .FirstOrDefault(p => p.Name == ComputerShopDbContextMock.Product);

            int productAmountSold = _ordersController.GetProductAmountSold(product);

            Assert.AreEqual(productAmountSold, ComputerShopDbContextMock.ProductAmountSold);
        }

        [TestMethod]
        public void AddProduct()
        {
            Order order = _computerShopDbContext.UnregisteredOrder;

            _ordersController.AddNewOrder(order);
            
            Assert.IsNotNull(_computerShopDbContext.Orders.FirstOrDefault(o => o == order));
        }
    }
}
