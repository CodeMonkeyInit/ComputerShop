using ComputerShop.Interfaces;
using ComputerShop.Model;
using System;
using System.Text;

namespace ComputerShop.Controller
{
    public class SaleRecieptController : IFormable
    {
        public string Form(Order order)
        {
            StringBuilder reciept = new StringBuilder();

            reciept.Append($"Чек на заказ №{order.ID}\n");

            foreach (Item item in order.Products)
            {
                reciept.Append(
                    $"Название: {item.Product.Name} Кол-во: {item.Amount} Сумма: {item.Product.Price * item.Amount}\n");
            }
            reciept.Append($"Дата {DateTime.Now}\n");
            return reciept.ToString();
        }
    }
}