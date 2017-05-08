using System;
using System.Collections.Generic;

namespace ComputerShop.Model
{
    class Order
    {
        private double total;

        public int ID { get; set; }
        
        public List<Item> Products { get; set; }
        
        public double Total
        {
            get
            {
                if (total == .0)
                {
                    foreach (Item item in Products)
                    {
                        total += item.Product.Price * item.Amount;
                    }
                }
                return total;
            }
            set
            {
                total = value;
            }
        }

        public DateTime Time { get; set; }

        public bool IsPaid { get; set; }

        public bool IsFinished { get; set; }
        
        public override string ToString()
        {
            return $"{ID}. {Time} {Total}";
        }

        public Order()
        {
            Products = new List<Item>();
            Time = DateTime.Now;
        }
    }
}
