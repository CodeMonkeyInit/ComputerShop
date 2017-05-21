using ComputerShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShop.Model.Interfaces;

namespace ComputerShop.Controller
{
    public class OrdersController
    {
        private readonly IComputerShopDbContext _dbContext;
        
        public IEnumerable<Order> Orders => _dbContext.Orders.ToList();

        public int GetProductAmountSold(Product product)
        {
            IEnumerable<Order> ordersWithProduct = Orders
                .Where(o => o.Products.Any(i => i.Product == product));

            IEnumerable<Item> itemsWithProduct = ordersWithProduct
                .Select(o => o.Products.First(i => i.Product == product));

            int amountSold = itemsWithProduct.Sum(i => i.Amount);

            return amountSold;
        }

        public void AddNewOrder(Order order)
        {
            _dbContext.Orders.Add(order);

            _dbContext.SaveChanges();
        }

        public OrdersController(IComputerShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}