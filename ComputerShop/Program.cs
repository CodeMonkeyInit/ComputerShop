using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerShop.Model;

namespace ComputerShop
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ComputerShopDbContext())
            {
                //var orders = context.Orders;
                //var order = new Order();
                //order.Products.Add(new Item(context.Stock.FirstOrDefault(product => product.ID == 1).ID, 2));
                //order.Products.Add(new Item(context.Stock.FirstOrDefault(product => product.ID == 1).ID, 2));

                //orders.Add(order);

                //context.SaveChanges();


                foreach (var order in context.Orders.Include("Products").ToList())
                {
                    Console.WriteLine("Новый заказ");

                    foreach (var item in order.Products)
                    {
                        Console.WriteLine(item.ProductID + " " + item.Amount);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
