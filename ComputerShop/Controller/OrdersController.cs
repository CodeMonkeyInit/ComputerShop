using ComputerShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Controller
{
    public class OrdersController
    {
        private readonly IComputerShopDbContext _dbContext;

        public readonly string LinqIncludeWithOrder = "Products.Product";

        public IEnumerable<Order> Orders => _dbContext.Orders.ToList();

        public int GetProductAmountSold(Product product)
        {
            //TODO check
            return Orders
                .Where(o => o.Products.Any(i => i.Product == product))
                .Select(o => o.Products.First())
                .Sum(i => i.Amount);
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