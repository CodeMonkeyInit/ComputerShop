using ComputerShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerShop.Controller
{
    class OrdersController
    {
        private IEnumerable<Order> orders;

        public readonly string LinqIncludeWithOrder = "Products.Product";

        public IEnumerable<Order> Orders
        {
            get
            {
                if (orders == null)
                {
                    using (var dbContext = new ComputerShopDbContext())
                    {
                        orders = dbContext.Orders.Include(LinqIncludeWithOrder).ToList();
                    }
                }
                return orders;
            }
        }

        public int GetProductAmountSold(Product product)
        {
            int productSold = 0;

            foreach (Order order in Orders)
            {
                Item orderItem = order.Products.First(item => item.ProductID == product.ID);
            }
            return productSold;
        }

        public void AddNewOrder(Order order)
        {
            using (var dbContext = new ComputerShopDbContext())
            {
                dbContext.Orders.Add(order);
            }
        }
    }
}