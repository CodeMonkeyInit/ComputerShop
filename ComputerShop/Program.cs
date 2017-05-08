using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShop.Model;
using ComputerShop.Controller;
using ComputerShop.Interfaces;
using ComputerShop.View;

namespace ComputerShop
{
    class Program
    {
        static void Test()
        {
            using (var context = new ComputerShopDbContext())
            {
                var orders = context.Orders;
                var newOrder = new Order();
                newOrder.Products.Add(new Item(context.Stock.FirstOrDefault(product => product.ID == 2).ID, 2));
                newOrder.Products.Add(new Item(context.Stock.FirstOrDefault(product => product.ID == 1).ID, 2));
                newOrder.Products.Add(new Item(context.Stock.FirstOrDefault(product => product.ID == 3).ID, 2));
                newOrder.Products.Add(new Item(context.Stock.FirstOrDefault(product => product.ID == 4).ID, 2));

                orders.Add(newOrder);

                context.SaveChanges();


                foreach (var order in context.Orders.Include("Products.Product").ToList())
                {
                    Console.WriteLine(new SaleRecieptController().Form(order));
                }
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            //Test();

            IUserInterface UI = new CashierUserInterface();

            UI.Render();
        }
    }
}
